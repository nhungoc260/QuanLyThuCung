USE QuanLyThuCung;

-- Thêm cột nếu chưa có
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id=OBJECT_ID('Customers') AND name='Email')
    ALTER TABLE Customers ADD Email NVARCHAR(100) NULL;
GO
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id=OBJECT_ID('Customers') AND name='OtherInfo')
    ALTER TABLE Customers ADD OtherInfo NVARCHAR(200) NULL;
GO

-- Update email
UPDATE Customers SET Email='nam.nguyen@gmail.com',   OtherInfo=N'Khách thân thiết'     WHERE Id=1  AND (Email IS NULL OR Email='');
UPDATE Customers SET Email='mai.tran@gmail.com',     OtherInfo=N'Mua thường xuyên'     WHERE Id=2  AND (Email IS NULL OR Email='');
UPDATE Customers SET Email='hung.le@gmail.com',      OtherInfo=N'Khách VIP'            WHERE Id=3  AND (Email IS NULL OR Email='');
UPDATE Customers SET Email='lan.pham@gmail.com',     OtherInfo=N'Thích đồ cao cấp'     WHERE Id=4  AND (Email IS NULL OR Email='');
UPDATE Customers SET Email='duc.hoang@gmail.com',    OtherInfo=N''                     WHERE Id=5  AND (Email IS NULL OR Email='');
UPDATE Customers SET Email='huong.ngo@gmail.com',    OtherInfo=N'Hay mua cuối tuần'    WHERE Id=6  AND (Email IS NULL OR Email='');
UPDATE Customers SET Email='hung.vu@gmail.com',      OtherInfo=N''                     WHERE Id=7  AND (Email IS NULL OR Email='');
UPDATE Customers SET Email='lan.do@gmail.com',       OtherInfo=N'Khách quen'           WHERE Id=8  AND (Email IS NULL OR Email='');
UPDATE Customers SET Email='minh.bui@gmail.com',     OtherInfo=N''                     WHERE Id=9  AND (Email IS NULL OR Email='');
UPDATE Customers SET Email='nga.ly@gmail.com',       OtherInfo=N'Thích dịch vụ tắm'   WHERE Id=10 AND (Email IS NULL OR Email='');
UPDATE Customers SET Email='phong.dinh@gmail.com',   OtherInfo=N''                     WHERE Id=11 AND (Email IS NULL OR Email='');
UPDATE Customers SET Email='quynh.mai@gmail.com',    OtherInfo=N'Mua định kỳ'          WHERE Id=12 AND (Email IS NULL OR Email='');
UPDATE Customers SET Email='son.ta@gmail.com',       OtherInfo=N''                     WHERE Id=13 AND (Email IS NULL OR Email='');
UPDATE Customers SET Email='trang.vo@gmail.com',     OtherInfo=N'Khách thân thiết'     WHERE Id=14 AND (Email IS NULL OR Email='');
UPDATE Customers SET Email='tuan.phan@gmail.com',    OtherInfo=N''                     WHERE Id=15 AND (Email IS NULL OR Email='');
UPDATE Customers SET Email='hoa.truong@gmail.com',   OtherInfo=N'Khách mới'            WHERE Id=16 AND (Email IS NULL OR Email='');
UPDATE Customers SET Email='khai.luu@gmail.com',     OtherInfo=N''                     WHERE Id=17 AND (Email IS NULL OR Email='');
UPDATE Customers SET Email='phuong.dang@gmail.com',  OtherInfo=N'Hay đặt lịch trước'  WHERE Id=18 AND (Email IS NULL OR Email='');
UPDATE Customers SET Email='binh.cao@gmail.com',     OtherInfo=N''                     WHERE Id=19 AND (Email IS NULL OR Email='');
UPDATE Customers SET Email='cam.huynh@gmail.com',    OtherInfo=N'Khách VIP'            WHERE Id=20 AND (Email IS NULL OR Email='');
GO

-- =============================================
-- STORED PROCEDURES
-- =============================================
IF OBJECT_ID('sp_GetPets','P') IS NOT NULL DROP PROCEDURE sp_GetPets;
GO
CREATE PROCEDURE sp_GetPets AS
BEGIN
    SET NOCOUNT ON;
    SELECT p.Id, p.PetName, p.Species, p.Breed, p.Age, p.CustomerId, c.CustomerName
    FROM Pets p INNER JOIN Customers c ON p.CustomerId = c.Id
END;
GO

IF OBJECT_ID('sp_AddPet','P') IS NOT NULL DROP PROCEDURE sp_AddPet;
GO
CREATE PROCEDURE sp_AddPet
    @PetName NVARCHAR(100), @Species NVARCHAR(50),
    @Breed   NVARCHAR(100), @Age INT, @CustomerId INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Pets (PetName,Species,Breed,Age,CustomerId)
    VALUES (@PetName,@Species,@Breed,@Age,@CustomerId);
END;
GO

IF OBJECT_ID('sp_UpdatePet','P') IS NOT NULL DROP PROCEDURE sp_UpdatePet;
GO
CREATE PROCEDURE sp_UpdatePet
    @PetId INT, @PetName NVARCHAR(100), @Species NVARCHAR(50),
    @Breed NVARCHAR(100), @Age INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Pets SET PetName=@PetName, Species=@Species, Breed=@Breed, Age=@Age
    WHERE Id=@PetId;
END;
GO

IF OBJECT_ID('sp_DeletePet','P') IS NOT NULL DROP PROCEDURE sp_DeletePet;
GO
CREATE PROCEDURE sp_DeletePet @PetId INT AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Pets WHERE Id=@PetId;
END;
GO

IF OBJECT_ID('sp_GetCustomers','P') IS NOT NULL DROP PROCEDURE sp_GetCustomers;
GO
CREATE PROCEDURE sp_GetCustomers AS
BEGIN
    SELECT Id, CustomerName, Phone, Address,
           ISNULL(Email,'') AS Email,
           ISNULL(OtherInfo,'') AS OtherInfo
    FROM Customers ORDER BY Id
END
GO

IF OBJECT_ID('sp_GetServices','P') IS NOT NULL DROP PROCEDURE sp_GetServices;
GO
CREATE PROCEDURE sp_GetServices AS
BEGIN
    SELECT * FROM Services
END
GO

IF OBJECT_ID('sp_CreateAppointment','P') IS NOT NULL DROP PROCEDURE sp_CreateAppointment;
GO
CREATE PROCEDURE sp_CreateAppointment
    @PetId INT, @ServiceId INT, @AppointmentDate DATETIME
AS
BEGIN
    INSERT INTO Appointments (PetId,ServiceId,AppointmentDate)
    VALUES (@PetId,@ServiceId,@AppointmentDate)
END
GO

IF OBJECT_ID('sp_GetDashboardStats','P') IS NOT NULL DROP PROCEDURE sp_GetDashboardStats;
GO
CREATE PROCEDURE sp_GetDashboardStats AS
BEGIN
    SELECT
        (SELECT COUNT(*) FROM Pets)         AS TotalPets,
        (SELECT COUNT(*) FROM Customers)    AS TotalCustomers,
        (SELECT COUNT(*) FROM Services)     AS TotalServices,
        (SELECT COUNT(*) FROM Appointments) AS TotalAppointments
END
GO

-- =============================================
-- SP LỊCH SỬ MUA HÀNG
-- =============================================
IF OBJECT_ID('sp_GetHoaDonByCustomer','P') IS NOT NULL DROP PROCEDURE sp_GetHoaDonByCustomer;
GO
CREATE PROCEDURE sp_GetHoaDonByCustomer @CustomerId INT AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        h.Id       AS MaHD,
        h.NgayLap,
        h.TongTien,
        h.NhanVien,
        h.GhiChu
    FROM HoaDon h
    WHERE h.CustomerId = @CustomerId
    ORDER BY h.NgayLap DESC
END
GO

IF OBJECT_ID('sp_GetChiTietHoaDon','P') IS NOT NULL DROP PROCEDURE sp_GetChiTietHoaDon;
GO
CREATE PROCEDURE sp_GetChiTietHoaDon @HoaDonId INT AS
BEGIN
    SET NOCOUNT ON;
    SELECT TenSanPham, SoLuong, DonGia, ThanhTien, LoaiHang
    FROM ChiTietHoaDon
    WHERE HoaDonId = @HoaDonId
END
GO

ALTER DATABASE QuanLyThuCung COLLATE Vietnamese_CI_AS;
GO

PRINT '===================================='
PRINT 'AdditionalProcedures chạy thành công'
PRINT '===================================='
SELECT * FROM Customers;
GO