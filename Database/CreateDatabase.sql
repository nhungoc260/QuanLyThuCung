-- =============================================
-- Script tạo Database Quản Lý Thú Cưng
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'QuanLyThuCung')
BEGIN
    CREATE DATABASE QuanLyThuCung COLLATE Vietnamese_CI_AS;
END
ELSE
BEGIN
    ALTER DATABASE QuanLyThuCung COLLATE Vietnamese_CI_AS;
END
GO

USE QuanLyThuCung;
GO

-- =============================================
-- 1. BẢNG USERS
-- =============================================
IF OBJECT_ID('Users', 'U') IS NOT NULL DROP TABLE Users;
GO
CREATE TABLE Users
(
    Id            INT IDENTITY(1,1) PRIMARY KEY,
    Username      NVARCHAR(50)  NOT NULL UNIQUE,
    PasswordHash  NVARCHAR(255) NOT NULL,
    FullName      NVARCHAR(100) NOT NULL,
    Email         NVARCHAR(100) NOT NULL UNIQUE,
    CreatedDate   DATETIME      NOT NULL DEFAULT GETDATE(),
    LastLoginDate DATETIME      NULL,
    IsActive      BIT           NOT NULL DEFAULT 1,
    CONSTRAINT CK_Users_Email    CHECK (Email LIKE '%@%.%'),
    CONSTRAINT CK_Users_Username CHECK (LEN(Username) >= 3)
);
GO
CREATE INDEX IX_Users_Username ON Users(Username);
CREATE INDEX IX_Users_Email    ON Users(Email);
CREATE INDEX IX_Users_IsActive ON Users(IsActive);
GO

-- =============================================
-- 2. BẢNG TASKS
-- =============================================
IF OBJECT_ID('Tasks', 'U') IS NOT NULL DROP TABLE Tasks;
GO
CREATE TABLE Tasks
(
    Id            INT IDENTITY(1,1) PRIMARY KEY,
    Title         NVARCHAR(200) NOT NULL,
    Description   NVARCHAR(MAX),
    UserId        INT           NOT NULL,
    Priority      NVARCHAR(20)  NOT NULL DEFAULT 'Medium',
    Status        NVARCHAR(20)  NOT NULL DEFAULT 'Todo',
    Category      NVARCHAR(20)  NOT NULL DEFAULT 'Work',
    DueDate       DATETIME      NOT NULL,
    CreatedDate   DATETIME      NOT NULL DEFAULT GETDATE(),
    CompletedDate DATETIME      NULL,
    IsDeleted     BIT           NOT NULL DEFAULT 0,
    DeletedDate   DATETIME      NULL,
    CONSTRAINT FK_Tasks_Users    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
    CONSTRAINT CK_Tasks_Priority CHECK (Priority  IN ('High','Medium','Low')),
    CONSTRAINT CK_Tasks_Status   CHECK (Status    IN ('Todo','Doing','Done')),
    CONSTRAINT CK_Tasks_Category CHECK (Category  IN ('Work','Personal','Study')),
    CONSTRAINT CK_Tasks_Title    CHECK (LEN(TRIM(Title)) > 0)
);
GO
CREATE INDEX IX_Tasks_UserId   ON Tasks(UserId);
CREATE INDEX IX_Tasks_Status   ON Tasks(Status);
CREATE INDEX IX_Tasks_Priority ON Tasks(Priority);
CREATE INDEX IX_Tasks_Category ON Tasks(Category);
CREATE INDEX IX_Tasks_DueDate  ON Tasks(DueDate);
GO

-- =============================================
-- 3. BẢNG TASK HISTORY
-- =============================================
IF OBJECT_ID('TaskHistory', 'U') IS NOT NULL DROP TABLE TaskHistory;
GO
CREATE TABLE TaskHistory
(
    Id         INT IDENTITY(1,1) PRIMARY KEY,
    TaskId     INT           NOT NULL,
    Action     NVARCHAR(50)  NOT NULL,
    OldStatus  NVARCHAR(20)  NULL,
    NewStatus  NVARCHAR(20)  NULL,
    Notes      NVARCHAR(500) NULL,
    ActionDate DATETIME      NOT NULL DEFAULT GETDATE(),
    UserId     INT           NOT NULL,
    CONSTRAINT FK_TaskHistory_Tasks  FOREIGN KEY (TaskId) REFERENCES Tasks(Id) ON DELETE CASCADE,
    CONSTRAINT FK_TaskHistory_Users  FOREIGN KEY (UserId) REFERENCES Users(Id),
    CONSTRAINT CK_TaskHistory_Action CHECK (Action IN ('Created','Updated','Completed','Deleted','StatusChanged'))
);
GO
CREATE INDEX IX_TaskHistory_TaskId ON TaskHistory(TaskId);
CREATE INDEX IX_TaskHistory_UserId ON TaskHistory(UserId);
GO

-- =============================================
-- 4. BẢNG SETTINGS
-- =============================================
IF OBJECT_ID('Settings', 'U') IS NOT NULL DROP TABLE Settings;
GO
CREATE TABLE Settings
(
    Id           INT IDENTITY(1,1) PRIMARY KEY,
    SettingKey   NVARCHAR(100) NOT NULL UNIQUE,
    SettingValue NVARCHAR(255) NOT NULL,
    Description  NVARCHAR(500) NULL,
    CreatedDate  DATETIME      NOT NULL DEFAULT GETDATE(),
    UpdatedDate  DATETIME      NULL
);
GO
INSERT INTO Settings (SettingKey, SettingValue, Description) VALUES
('MAX_LOGIN_ATTEMPTS',    '5',  N'Số lần đăng nhập sai tối đa'),
('LOCKOUT_MINUTES',       '15', N'Thời gian khóa tài khoản'),
('ERROR_USERNAME_EXISTS', '-1', N'Username đã tồn tại'),
('ERROR_EMAIL_EXISTS',    '-2', N'Email đã tồn tại');
GO

-- =============================================
-- 5. BẢNG CUSTOMERS
-- =============================================
IF OBJECT_ID('Customers', 'U') IS NOT NULL DROP TABLE Customers;
GO
CREATE TABLE Customers
(
    Id           INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName NVARCHAR(100) NOT NULL,
    Phone        NVARCHAR(20)  NULL,
    Address      NVARCHAR(200) NULL,
    Email        NVARCHAR(100) NULL,
    OtherInfo    NVARCHAR(200) NULL
);
GO

-- =============================================
-- 6. BẢNG PETS
-- =============================================
IF OBJECT_ID('Pets', 'U') IS NOT NULL DROP TABLE Pets;
GO
CREATE TABLE Pets
(
    Id         INT IDENTITY(1,1) PRIMARY KEY,
    PetName    NVARCHAR(100) NOT NULL,
    Species    NVARCHAR(50)  NULL,
    Breed      NVARCHAR(100) NULL,
    Age        INT           NULL,
    CustomerId INT           NULL
);
GO

-- =============================================
-- 7. BẢNG SERVICES
-- =============================================
IF OBJECT_ID('Services', 'U') IS NOT NULL DROP TABLE Services;
GO
CREATE TABLE Services
(
    Id          INT IDENTITY(1,1) PRIMARY KEY,
    ServiceName NVARCHAR(100) NOT NULL,
    Price       DECIMAL(10,2) NULL
);
GO

-- =============================================
-- 8. BẢNG APPOINTMENTS
-- =============================================
IF OBJECT_ID('Appointments', 'U') IS NOT NULL DROP TABLE Appointments;
GO
CREATE TABLE Appointments
(
    Id              INT IDENTITY(1,1) PRIMARY KEY,
    PetId           INT      NULL,
    ServiceId       INT      NULL,
    AppointmentDate DATETIME NULL
);
GO

-- =============================================
-- 9. BẢNG HOADON
-- =============================================
IF OBJECT_ID('HoaDon', 'U') IS NOT NULL DROP TABLE HoaDon;
GO
CREATE TABLE HoaDon
(
    Id         INT IDENTITY(1,1) PRIMARY KEY,
    CustomerId INT           NOT NULL,
    NgayLap    DATETIME      NOT NULL DEFAULT GETDATE(),
    TongTien   DECIMAL(12,2) NOT NULL DEFAULT 0,
    NhanVien   NVARCHAR(100) NULL,
    GhiChu     NVARCHAR(200) NULL
);
GO

-- =============================================
-- 10. BẢNG CHITIETHOADON
-- =============================================
IF OBJECT_ID('ChiTietHoaDon', 'U') IS NOT NULL DROP TABLE ChiTietHoaDon;
GO
CREATE TABLE ChiTietHoaDon
(
    Id         INT IDENTITY(1,1) PRIMARY KEY,
    HoaDonId   INT           NOT NULL,
    TenSanPham NVARCHAR(200) NOT NULL,
    SoLuong    INT           NOT NULL DEFAULT 1,
    DonGia     DECIMAL(12,2) NOT NULL DEFAULT 0,
    ThanhTien  DECIMAL(12,2) NOT NULL DEFAULT 0,
    LoaiHang   NVARCHAR(20)  NOT NULL DEFAULT 'SanPham'
);
GO

-- =============================================
-- VIEWS
-- =============================================
IF OBJECT_ID('vw_StatusStats','V')   IS NOT NULL DROP VIEW vw_StatusStats
GO
CREATE VIEW vw_StatusStats AS
SELECT Status, COUNT(*) Count FROM Tasks WHERE IsDeleted = 0 GROUP BY Status
GO

IF OBJECT_ID('vw_PriorityStats','V') IS NOT NULL DROP VIEW vw_PriorityStats
GO
CREATE VIEW vw_PriorityStats AS
SELECT Priority, COUNT(*) Count FROM Tasks WHERE IsDeleted = 0 GROUP BY Priority
GO

-- =============================================
-- STORED PROCEDURES
-- =============================================
IF OBJECT_ID('sp_GetRecentTasks','P') IS NOT NULL DROP PROCEDURE sp_GetRecentTasks
GO
CREATE PROCEDURE sp_GetRecentTasks @UserId INT
AS
BEGIN
    SELECT TOP 10 * FROM Tasks WHERE UserId = @UserId ORDER BY CreatedDate DESC
END
GO

IF OBJECT_ID('sp_UserLogin','P') IS NOT NULL DROP PROCEDURE sp_UserLogin
GO
CREATE PROCEDURE sp_UserLogin @Username NVARCHAR(50), @Password NVARCHAR(255)
AS
BEGIN
    SELECT * FROM Users
    WHERE Username=@Username AND PasswordHash=@Password AND IsActive=1
END
GO

IF OBJECT_ID('sp_ResetPassword','P') IS NOT NULL DROP PROCEDURE sp_ResetPassword
GO
CREATE PROCEDURE sp_ResetPassword
    @UsernameOrEmail NVARCHAR(100),
    @NewPassword     NVARCHAR(255),
    @Result          INT OUTPUT
AS
BEGIN
    DECLARE @id INT, @active BIT
    SELECT @id=Id, @active=IsActive FROM Users
    WHERE Username=@UsernameOrEmail OR Email=@UsernameOrEmail

    IF @id IS NULL BEGIN SET @Result=-1 RETURN END
    IF @active=0   BEGIN SET @Result=-2 RETURN END

    UPDATE Users SET PasswordHash=@NewPassword WHERE Id=@id
    SET @Result=1
END
GO

IF OBJECT_ID('sp_UserRegister','P') IS NOT NULL DROP PROCEDURE sp_UserRegister
GO
CREATE PROCEDURE sp_UserRegister
    @Username NVARCHAR(50),  @Password NVARCHAR(255),
    @FullName NVARCHAR(100), @Email    NVARCHAR(100),
    @UserId   INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Users WHERE Username=@Username) BEGIN SET @UserId=-1 RETURN END
    IF EXISTS (SELECT 1 FROM Users WHERE Email=@Email)       BEGIN SET @UserId=-2 RETURN END
    INSERT INTO Users (Username,PasswordHash,FullName,Email,IsActive)
    VALUES (@Username,@Password,@FullName,@Email,1)
    SET @UserId=SCOPE_IDENTITY()
END
GO

-- =============================================
-- TRIGGER
-- =============================================
IF OBJECT_ID('tr_Tasks_Insert','TR') IS NOT NULL DROP TRIGGER tr_Tasks_Insert
GO
CREATE TRIGGER tr_Tasks_Insert ON Tasks AFTER INSERT
AS
BEGIN
    INSERT INTO TaskHistory(TaskId,Action,NewStatus,UserId)
    SELECT Id,'Created',Status,UserId FROM inserted
END
GO

PRINT '===================================='
PRINT 'CreateDatabase.sql chạy thành công!'
PRINT '===================================='
GO