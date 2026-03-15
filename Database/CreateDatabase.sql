-- =============================================
-- Script tạo Database Quản Lý Thú Cưng
-- Hệ thống quản lý với kiến trúc 3 lớp
-- =============================================

-- Tạo Database với collation hỗ trợ tiếng Việt
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'QuanLyThuCung')
BEGIN
    CREATE DATABASE QuanLyThuCung
    COLLATE Vietnamese_CI_AS;
END
ELSE
BEGIN
    -- Nếu database đã tồn tại, đổi collation
    ALTER DATABASE QuanLyThuCung COLLATE Vietnamese_CI_AS;
END
GO

USE QuanLyThuCung;
GO

-- =============================================
-- 1. BẢNG USERS
-- =============================================

IF OBJECT_ID('Users', 'U') IS NOT NULL
    DROP TABLE Users;
GO

CREATE TABLE Users
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    LastLoginDate DATETIME NULL,
    IsActive BIT NOT NULL DEFAULT 1,

    CONSTRAINT CK_Users_Email CHECK (Email LIKE '%@%.%'),
    CONSTRAINT CK_Users_Username CHECK (LEN(Username) >= 3)
);
GO

CREATE INDEX IX_Users_Username ON Users(Username);
CREATE INDEX IX_Users_Email ON Users(Email);
CREATE INDEX IX_Users_IsActive ON Users(IsActive);
GO

-- =============================================
-- 2. BẢNG TASKS
-- =============================================

IF OBJECT_ID('Tasks', 'U') IS NOT NULL
    DROP TABLE Tasks;
GO

CREATE TABLE Tasks
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    UserId INT NOT NULL,
    Priority NVARCHAR(20) NOT NULL DEFAULT 'Medium',
    Status NVARCHAR(20) NOT NULL DEFAULT 'Todo',
    Category NVARCHAR(20) NOT NULL DEFAULT 'Work',
    DueDate DATETIME NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    CompletedDate DATETIME NULL,
    IsDeleted BIT NOT NULL DEFAULT 0,
    DeletedDate DATETIME NULL,

    CONSTRAINT FK_Tasks_Users FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,

    CONSTRAINT CK_Tasks_Priority CHECK (Priority IN ('High','Medium','Low')),
    CONSTRAINT CK_Tasks_Status CHECK (Status IN ('Todo','Doing','Done')),
    CONSTRAINT CK_Tasks_Category CHECK (Category IN ('Work','Personal','Study')),
    CONSTRAINT CK_Tasks_Title CHECK (LEN(TRIM(Title)) > 0)
);
GO

CREATE INDEX IX_Tasks_UserId ON Tasks(UserId);
CREATE INDEX IX_Tasks_Status ON Tasks(Status);
CREATE INDEX IX_Tasks_Priority ON Tasks(Priority);
CREATE INDEX IX_Tasks_Category ON Tasks(Category);
CREATE INDEX IX_Tasks_DueDate ON Tasks(DueDate);
GO

-- =============================================
-- 3. BẢNG TASK HISTORY
-- =============================================

IF OBJECT_ID('TaskHistory', 'U') IS NOT NULL
    DROP TABLE TaskHistory;
GO

CREATE TABLE TaskHistory
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TaskId INT NOT NULL,
    Action NVARCHAR(50) NOT NULL,
    OldStatus NVARCHAR(20) NULL,
    NewStatus NVARCHAR(20) NULL,
    Notes NVARCHAR(500) NULL,
    ActionDate DATETIME NOT NULL DEFAULT GETDATE(),
    UserId INT NOT NULL,

    CONSTRAINT FK_TaskHistory_Tasks 
        FOREIGN KEY (TaskId) REFERENCES Tasks(Id) ON DELETE CASCADE,

    CONSTRAINT FK_TaskHistory_Users 
        FOREIGN KEY (UserId) REFERENCES Users(Id),

    CONSTRAINT CK_TaskHistory_Action 
        CHECK (Action IN ('Created','Updated','Completed','Deleted','StatusChanged'))
);
GO

CREATE INDEX IX_TaskHistory_TaskId ON TaskHistory(TaskId);
CREATE INDEX IX_TaskHistory_UserId ON TaskHistory(UserId);
GO

-- =============================================
-- 4. BẢNG SETTINGS
-- =============================================

IF OBJECT_ID('Settings', 'U') IS NOT NULL
    DROP TABLE Settings;
GO

CREATE TABLE Settings
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SettingKey NVARCHAR(100) NOT NULL UNIQUE,
    SettingValue NVARCHAR(255) NOT NULL,
    Description NVARCHAR(500) NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL
);
GO

INSERT INTO Settings (SettingKey, SettingValue, Description)
VALUES 
('MAX_LOGIN_ATTEMPTS','5',N'Số lần đăng nhập sai tối đa'),
('LOCKOUT_MINUTES','15',N'Thời gian khóa tài khoản'),
('ERROR_USERNAME_EXISTS','-1',N'Username đã tồn tại'),
('ERROR_EMAIL_EXISTS','-2',N'Email đã tồn tại');
GO

-- =============================================
-- VIEWS
-- =============================================

IF OBJECT_ID('vw_StatusStats','V') IS NOT NULL
DROP VIEW vw_StatusStats
GO

CREATE VIEW vw_StatusStats
AS
SELECT Status, COUNT(*) Count
FROM Tasks
WHERE IsDeleted = 0
GROUP BY Status
GO

IF OBJECT_ID('vw_PriorityStats','V') IS NOT NULL
DROP VIEW vw_PriorityStats
GO

CREATE VIEW vw_PriorityStats
AS
SELECT Priority, COUNT(*) Count
FROM Tasks
WHERE IsDeleted = 0
GROUP BY Priority
GO

-- =============================================
-- STORED PROCEDURES
-- =============================================

IF OBJECT_ID('sp_GetRecentTasks','P') IS NOT NULL
DROP PROCEDURE sp_GetRecentTasks
GO

CREATE PROCEDURE sp_GetRecentTasks
@UserId INT
AS
BEGIN

SELECT TOP 10 *
FROM Tasks
WHERE UserId = @UserId
ORDER BY CreatedDate DESC

END
GO

IF OBJECT_ID('sp_UserLogin','P') IS NOT NULL
DROP PROCEDURE sp_UserLogin
GO

CREATE PROCEDURE sp_UserLogin
@Username NVARCHAR(50),
@Password NVARCHAR(255)
AS
BEGIN

SELECT *
FROM Users
WHERE Username=@Username
AND PasswordHash=@Password
AND IsActive=1

END
GO

-- =============================================
-- TRIGGER
-- =============================================

IF OBJECT_ID('tr_Tasks_Insert','TR') IS NOT NULL
DROP TRIGGER tr_Tasks_Insert
GO

CREATE TRIGGER tr_Tasks_Insert
ON Tasks
AFTER INSERT
AS
BEGIN

INSERT INTO TaskHistory(TaskId,Action,NewStatus,UserId)
SELECT Id,'Created',Status,UserId
FROM inserted

END
GO

PRINT 'Database QuanLyThuCung đã được tạo thành công!'
PRINT 'Tables: Users, Tasks, TaskHistory, Settings'
PRINT 'Views: vw_StatusStats, vw_PriorityStats'
PRINT 'Stored Procedures: sp_GetRecentTasks'
PRINT 'Triggers: tr_Tasks_Insert'
GO