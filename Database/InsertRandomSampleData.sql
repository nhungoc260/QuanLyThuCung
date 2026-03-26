USE QuanLyThuCung
GO

PRINT '===================================='
PRINT 'TẠO DỮ LIỆU HỆ THỐNG THÚ CƯNG'
PRINT '===================================='

DECLARE @Password    NVARCHAR(255) = '123456'
DECLARE @SoLuongUsers INT = 15
DECLARE @Counter     INT = 1
DECLARE @Username    NVARCHAR(50)
DECLARE @FullName    NVARCHAR(100)
DECLARE @Email       NVARCHAR(100)

CREATE TABLE #TempNames (FirstName NVARCHAR(50), LastName NVARCHAR(50))
INSERT INTO #TempNames VALUES
(N'Nguyễn Văn',N'An'),  (N'Trần Thị',N'Bình'),  (N'Lê Văn',N'Cường'),
(N'Phạm Thị',N'Dung'),  (N'Hoàng Văn',N'Đức'),  (N'Ngô Thị',N'Hương'),
(N'Vũ Văn',N'Hùng'),    (N'Đỗ Thị',N'Lan'),     (N'Bùi Văn',N'Minh'),
(N'Lý Thị',N'Nga'),     (N'Đinh Văn',N'Phong'),  (N'Mai Thị',N'Quỳnh'),
(N'Tạ Văn',N'Sơn'),     (N'Võ Thị',N'Trang'),   (N'Phan Văn',N'Tuấn')

-- =============================================
-- USERS
-- =============================================
WHILE @Counter <= @SoLuongUsers
BEGIN
    SELECT TOP 1 @FullName = FirstName + ' ' + LastName FROM #TempNames ORDER BY NEWID()
    SET @Username = 'user' + CAST(@Counter AS VARCHAR)
    SET @Email    = @Username + '@example.com'
    IF NOT EXISTS (SELECT 1 FROM Users WHERE Username=@Username)
    BEGIN
        INSERT INTO Users (Username,PasswordHash,FullName,Email,CreatedDate,IsActive)
        VALUES (@Username,@Password,@FullName,@Email,GETDATE(),1)
        PRINT 'Đã tạo user: ' + @Username
    END
    SET @Counter = @Counter + 1
END

IF NOT EXISTS (SELECT 1 FROM Users WHERE Username='admin')
BEGIN
    INSERT INTO Users (Username,PasswordHash,FullName,Email,CreatedDate,IsActive)
    VALUES ('admin',@Password,N'Quản trị viên','admin@example.com',GETDATE(),1)
    PRINT 'Đã tạo admin'
END

-- Thêm cột nếu chưa có
IF OBJECT_ID('Customers') IS NOT NULL
BEGIN
    IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id=OBJECT_ID('Customers') AND name='Email')
        ALTER TABLE Customers ADD Email NVARCHAR(100) NULL;
    IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id=OBJECT_ID('Customers') AND name='OtherInfo')
        ALTER TABLE Customers ADD OtherInfo NVARCHAR(200) NULL;
END

IF OBJECT_ID('Services') IS NOT NULL
BEGIN
    IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id=OBJECT_ID('Services') AND name='Description')
        ALTER TABLE Services ADD Description NVARCHAR(500) NULL;
END

IF OBJECT_ID('HoaDon') IS NULL
BEGIN
    CREATE TABLE HoaDon (
        Id         INT IDENTITY PRIMARY KEY,
        CustomerId INT           NOT NULL,
        NgayLap    DATETIME      NOT NULL DEFAULT GETDATE(),
        TongTien   DECIMAL(12,2) NOT NULL DEFAULT 0,
        NhanVien   NVARCHAR(100) NULL,
        GhiChu     NVARCHAR(200) NULL
    )
END

IF OBJECT_ID('ChiTietHoaDon') IS NULL
BEGIN
    CREATE TABLE ChiTietHoaDon (
        Id         INT IDENTITY PRIMARY KEY,
        HoaDonId   INT           NOT NULL,
        TenSanPham NVARCHAR(200) NOT NULL,
        SoLuong    INT           NOT NULL DEFAULT 1,
        DonGia     DECIMAL(12,2) NOT NULL DEFAULT 0,
        ThanhTien  DECIMAL(12,2) NOT NULL DEFAULT 0,
        LoaiHang   NVARCHAR(20)  NOT NULL DEFAULT 'SanPham'
    )
END

-- Dọn duplicate
DELETE FROM Appointments;
DELETE FROM Pets      WHERE Id NOT IN (SELECT MIN(Id) FROM Pets      GROUP BY PetName, CustomerId);
DELETE FROM Customers WHERE Id NOT IN (SELECT MIN(Id) FROM Customers GROUP BY CustomerName, Phone);

DBCC CHECKIDENT ('Customers',    RESEED, 0);
DBCC CHECKIDENT ('Pets',         RESEED, 0);
DBCC CHECKIDENT ('Appointments', RESEED, 0);

-- =============================================
-- KHÁCH HÀNG
-- =============================================
IF NOT EXISTS (SELECT 1 FROM Customers)
BEGIN
    INSERT INTO Customers (CustomerName, Phone, Address, Email, OtherInfo) VALUES
    (N'Nguyễn Văn Nam',  '0901234567', N'123 Lý Thường Kiệt, Q.10, TP.HCM',        'nam.nguyen@gmail.com',   N'Khách thân thiết'),
    (N'Trần Thị Mai',    '0902345678', N'456 Lê Lợi, P.1, Q.1, TP.HCM',            'mai.tran@gmail.com',     N'Mua thường xuyên'),
    (N'Lê Văn Hùng',     '0903456789', N'789 Trần Hưng Đạo, Q.5, TP.HCM',          'hung.le@gmail.com',      N'Khách VIP'),
    (N'Phạm Thị Lan',    '0904567890', N'321 CMT8, P.12, Q.10, TP.HCM',            'lan.pham@gmail.com',     N'Thích đồ cao cấp'),
    (N'Hoàng Văn Đức',   '0905678901', N'654 Nguyễn Đình Chiểu, P.3, Q.1, TP.HCM', 'duc.hoang@gmail.com',    N''),
    (N'Ngô Thị Hương',   '0906789012', N'12 Võ Văn Tần, P.6, Q.3, TP.HCM',         'huong.ngo@gmail.com',    N'Hay mua vào cuối tuần'),
    (N'Vũ Văn Hùng',     '0907890123', N'34 Điện Biên Phủ, P.15, Bình Thạnh',      'hung.vu@gmail.com',      N''),
    (N'Đỗ Thị Lan',      '0908901234', N'56 Phan Xích Long, P.3, Phú Nhuận',        'lan.do@gmail.com',       N'Khách quen'),
    (N'Bùi Văn Minh',    '0909012345', N'78 Nguyễn Văn Cừ, P.2, Q.5, TP.HCM',     'minh.bui@gmail.com',     N''),
    (N'Lý Thị Nga',      '0910123456', N'90 Hùng Vương, P.9, Q.5, TP.HCM',         'nga.ly@gmail.com',       N'Thích dịch vụ tắm'),
    (N'Đinh Văn Phong',  '0911234567', N'102 Trường Chinh, Tân Bình, TP.HCM',       'phong.dinh@gmail.com',   N''),
    (N'Mai Thị Quỳnh',   '0912345678', N'204 Hoàng Văn Thụ, P.9, Phú Nhuận',       'quynh.mai@gmail.com',    N'Mua định kỳ hàng tháng'),
    (N'Tạ Văn Sơn',      '0913456789', N'306 Lạc Long Quân, P.5, Q.11, TP.HCM',    'son.ta@gmail.com',       N''),
    (N'Võ Thị Trang',    '0914567890', N'408 Âu Cơ, P.10, Q.11, TP.HCM',           'trang.vo@gmail.com',     N'Khách thân thiết'),
    (N'Phan Văn Tuấn',   '0915678901', N'510 Tô Hiến Thành, P.14, Q.10, TP.HCM',   'tuan.phan@gmail.com',    N''),
    (N'Trương Thị Hoa',  '0916789012', N'612 Ba Tháng Hai, P.14, Q.10, TP.HCM',    'hoa.truong@gmail.com',   N'Khách mới'),
    (N'Lưu Văn Khải',    '0917890123', N'714 Lý Thái Tổ, P.10, Q.10, TP.HCM',     'khai.luu@gmail.com',     N''),
    (N'Đặng Thị Phượng', '0918901234', N'816 Nguyễn Trãi, P.3, Q.5, TP.HCM',      'phuong.dang@gmail.com',  N'Hay đặt lịch trước'),
    (N'Cao Văn Bình',    '0919012345', N'918 Sư Vạn Hạnh, P.12, Q.10, TP.HCM',    'binh.cao@gmail.com',     N''),
    (N'Huỳnh Thị Cẩm',  '0920123456', N'120 Ngô Gia Tự, P.2, Q.10, TP.HCM',      'cam.huynh@gmail.com',    N'Khách VIP')
    PRINT 'Đã tạo 20 Customers'
END

-- =============================================
-- PETS
-- =============================================
IF NOT EXISTS (SELECT 1 FROM Pets)
BEGIN
    INSERT INTO Pets (PetName, Species, Breed, Age, CustomerId) VALUES
    (N'Milu',    'Dog',  'Poodle',           3,  1),
    (N'Mimi',    'Cat',  N'Anh lông ngắn',   2,  2),
    (N'Lucky',   'Dog',  'Golden Retriever', 4,  3),
    (N'Kitty',   'Cat',  N'Ba Tư',           1,  4),
    (N'Bông',    'Dog',  'Chihuahua',        2,  5),
    (N'Coco',    'Dog',  'Corgi',            3,  6),
    (N'Simba',   'Cat',  N'Mèo Anh',        1,  7),
    (N'Buddy',   'Dog',  'Labrador',         5,  8),
    (N'Nemo',    'Fish', N'Cá Vàng',         1,  9),
    (N'Kiki',    'Cat',  N'Mèo Xiêm',       2, 10),
    (N'Max',     'Dog',  'Husky',            3, 11),
    (N'Luna',    'Cat',  N'Mèo Ragdoll',    2, 12),
    (N'Charlie', 'Dog',  'Beagle',           4, 13),
    (N'Bella',   'Cat',  N'Mèo Maine Coon', 1, 14),
    (N'Rocky',   'Dog',  'Bulldog',          6, 15),
    (N'Lily',    'Cat',  N'Mèo Scottish',   3, 16),
    (N'Toby',    'Dog',  'Shih Tzu',         2, 17),
    (N'Daisy',   'Cat',  N'Mèo Bengal',     1, 18),
    (N'Oscar',   'Dog',  'Pomeranian',       4, 19),
    (N'Chloe',   'Cat',  N'Mèo Nga',        2, 20)
    PRINT 'Đã tạo 20 Pets'
END

-- =============================================
-- SERVICES
-- =============================================
IF NOT EXISTS (SELECT 1 FROM Services)
BEGIN
    INSERT INTO Services (ServiceName, Price, Description) VALUES
    (N'Khám sức khỏe',  100000, N'Kiểm tra sức khỏe tổng quát cho thú cưng'),
    (N'Tiêm phòng',     150000, N'Tiêm các loại vaccine phòng bệnh'),
    (N'Tắm rửa',         80000, N'Tắm rửa vệ sinh sạch sẽ cho thú cưng'),
    (N'Cắt tỉa lông',   120000, N'Cắt tỉa lông theo yêu cầu'),
    (N'Vệ sinh tai',     50000, N'Vệ sinh tai định kỳ'),
    (N'Cắt móng',        40000, N'Cắt móng an toàn cho thú cưng'),
    (N'Xét nghiệm máu', 200000, N'Xét nghiệm máu kiểm tra sức khỏe'),
    (N'Siêu âm',        300000, N'Siêu âm kiểm tra nội tạng')
    PRINT 'Đã tạo 8 Services'
END

-- =============================================
-- APPOINTMENTS
-- =============================================
IF NOT EXISTS (SELECT 1 FROM Appointments)
BEGIN
    INSERT INTO Appointments (PetId, ServiceId, AppointmentDate) VALUES
    (1,  1, GETDATE()),
    (2,  2, DATEADD(day,1,  GETDATE())),
    (3,  3, DATEADD(day,1,  GETDATE())),
    (4,  4, DATEADD(day,2,  GETDATE())),
    (5,  1, DATEADD(day,2,  GETDATE())),
    (6,  5, DATEADD(day,3,  GETDATE())),
    (7,  3, DATEADD(day,3,  GETDATE())),
    (8,  6, DATEADD(day,4,  GETDATE())),
    (9,  1, DATEADD(day,4,  GETDATE())),
    (10, 2, DATEADD(day,5,  GETDATE())),
    (11, 4, DATEADD(day,5,  GETDATE())),
    (12, 3, DATEADD(day,6,  GETDATE())),
    (13, 7, DATEADD(day,6,  GETDATE())),
    (14, 1, DATEADD(day,7,  GETDATE())),
    (15, 8, DATEADD(day,7,  GETDATE())),
    (16, 5, DATEADD(day,8,  GETDATE())),
    (17, 3, DATEADD(day,8,  GETDATE())),
    (18, 2, DATEADD(day,9,  GETDATE())),
    (19, 6, DATEADD(day,9,  GETDATE())),
    (20, 4, DATEADD(day,10, GETDATE()))
    PRINT 'Đã tạo 20 Appointments'
END

-- =============================================
-- HÓA ĐƠN
-- =============================================
IF NOT EXISTS (SELECT 1 FROM HoaDon)
BEGIN
    INSERT INTO HoaDon (CustomerId, NgayLap, TongTien, NhanVien, GhiChu) VALUES
    (1,  '2026-01-15 10:30:00', 1250000, N'Nguyễn Thị Hương', N'Thanh toán tiền mặt'),
    (1,  '2026-02-20 14:15:00',  850000, N'Trần Văn Nam',     N''),
    (2,  '2026-02-25 09:00:00', 2100000, N'Nguyễn Thị Hương', N'Thanh toán chuyển khoản'),
    (3,  '2026-03-01 11:00:00',  650000, N'Lê Thị Mai',       N''),
    (4,  '2026-03-05 16:20:00', 1500000, N'Nguyễn Thị Hương', N''),
    (5,  '2026-03-08 10:00:00',  750000, N'Trần Văn Nam',     N''),
    (6,  '2026-03-10 14:30:00',  450000, N'Lê Thị Mai',       N''),
    (7,  '2026-03-12 09:45:00',  980000, N'Nguyễn Thị Hương', N''),
    (8,  '2026-03-13 15:00:00',  320000, N'Trần Văn Nam',     N''),
    (9,  '2026-03-14 11:30:00',  560000, N'Lê Thị Mai',       N''),
    (10, '2026-03-15 10:00:00',  890000, N'Nguyễn Thị Hương', N''),
    (1,  '2026-03-16 14:00:00', 1100000, N'Trần Văn Nam',     N'Khách quen giảm 5%'),
    (2,  '2026-03-17 09:30:00',  420000, N'Lê Thị Mai',       N''),
    (3,  '2026-03-18 16:00:00',  780000, N'Nguyễn Thị Hương', N''),
    (4,  '2026-03-19 11:00:00',  650000, N'Trần Văn Nam',     N'')
    PRINT 'Đã tạo 15 HoaDon'

    INSERT INTO ChiTietHoaDon (HoaDonId, TenSanPham, SoLuong, DonGia, ThanhTien, LoaiHang) VALUES
    (1,  N'Thức ăn cho chó',  2, 150000, 300000, 'SanPham'),
    (1,  N'Khám sức khỏe',    1, 100000, 100000, 'DichVu'),
    (1,  N'Cắt tỉa lông',     1, 120000, 120000, 'DichVu'),
    (2,  N'Thức ăn cho mèo',  1, 200000, 200000, 'SanPham'),
    (2,  N'Tắm rửa',          1,  80000,  80000, 'DichVu'),
    (3,  N'Vòng cổ thú cưng', 3,  85000, 255000, 'SanPham'),
    (3,  N'Tiêm phòng',       2, 150000, 300000, 'DichVu'),
    (4,  N'Thức ăn cho chó',  1, 150000, 150000, 'SanPham'),
    (4,  N'Vệ sinh tai',      1,  50000,  50000, 'DichVu'),
    (5,  N'Lồng chó mèo',     1, 350000, 350000, 'SanPham'),
    (5,  N'Cắt móng',         1,  40000,  40000, 'DichVu'),
    (6,  N'Thức ăn cho mèo',  2, 200000, 400000, 'SanPham'),
    (7,  N'Tắm rửa',          1,  80000,  80000, 'DichVu'),
    (8,  N'Thức ăn cho chó',  3, 150000, 450000, 'SanPham'),
    (9,  N'Cắt tỉa lông',     1, 120000, 120000, 'DichVu'),
    (10, N'Vòng cổ thú cưng', 2,  85000, 170000, 'SanPham'),
    (11, N'Khám sức khỏe',    1, 100000, 100000, 'DichVu'),
    (12, N'Thức ăn cho chó',  4, 150000, 600000, 'SanPham'),
    (13, N'Tắm rửa',          1,  80000,  80000, 'DichVu'),
    (14, N'Tiêm phòng',       1, 150000, 150000, 'DichVu'),
    (15, N'Thức ăn cho mèo',  1, 200000, 200000, 'SanPham')
    PRINT 'Đã tạo ChiTietHoaDon'
END

-- =============================================
-- SANPHAM
-- =============================================
IF NOT EXISTS (SELECT 1 FROM SanPham)
BEGIN
    INSERT INTO SanPham (TenSP, LoaiSP, Gia, GiaXuat, SoLuong, TrangThai, MoTa) VALUES
    (N'Thức ăn chó Royal Canin 1kg',  N'Thức ăn',  120000, 150000, 50, N'Còn hàng',  N'Thức ăn hạt cho chó trưởng thành'),
    (N'Thức ăn mèo Whiskas 500g',     N'Thức ăn',   45000,  60000, 80, N'Còn hàng',  N'Thức ăn hạt cho mèo'),
    (N'Thức ăn chó Pedigree 3kg',     N'Thức ăn',  200000, 260000, 30, N'Còn hàng',  N'Thức ăn hạt dinh dưỡng cho chó'),
    (N'Vòng cổ chó size M',           N'Phụ kiện',  35000,  50000, 30, N'Còn hàng',  N'Vòng cổ da cho chó cỡ vừa'),
    (N'Lược chải lông thú cưng',      N'Phụ kiện',  25000,  40000, 15, N'Sắp hết',   N'Lược chải lông mềm đa năng'),
    (N'Áo cho chó size S',            N'Phụ kiện',  55000,  80000, 20, N'Còn hàng',  N'Áo thun cho chó nhỏ'),
    (N'Chuồng mèo inox',              N'Chuồng',   350000, 450000, 10, N'Còn hàng',  N'Chuồng inox cao cấp'),
    (N'Chuồng chó nhựa size L',       N'Chuồng',   280000, 370000,  8, N'Còn hàng',  N'Chuồng nhựa chắc chắn cho chó lớn'),
    (N'Đồ chơi bóng cao su cho chó',  N'Đồ chơi',   20000,  35000,  5, N'Sắp hết',   N'Bóng cao su an toàn cho thú cưng'),
    (N'Đồ chơi chuột nhồi bông',      N'Đồ chơi',   30000,  45000, 25, N'Còn hàng',  N'Đồ chơi chuột cho mèo'),
    (N'Sữa tắm thú cưng 250ml',       N'Vệ sinh',   55000,  75000, 25, N'Còn hàng',  N'Sữa tắm thơm dịu cho thú cưng'),
    (N'Cát vệ sinh mèo 5L',           N'Vệ sinh',   80000, 110000,  0, N'Hết hàng',  N'Cát vệ sinh không mùi cho mèo'),
    (N'Khăn tắm thú cưng',            N'Vệ sinh',   40000,  60000, 18, N'Còn hàng',  N'Khăn siêu thấm cho thú cưng'),
    (N'Vitamin tổng hợp cho chó',     N'Thuốc',     95000, 130000, 12, N'Còn hàng',  N'Bổ sung vitamin cho chó'),
    (N'Thuốc nhỏ gáy trị ve chó',     N'Thuốc',     75000, 100000,  0, N'Hết hàng',  N'Thuốc trị ve rận cho chó')
    PRINT 'Đã tạo 15 SanPham'
END

DROP TABLE #TempNames

PRINT '===================================='
PRINT 'HOÀN TẤT!'
PRINT 'admin / 123456 | user1 / 123456'
PRINT '===================================='

SELECT * FROM Customers;
SELECT * FROM Pets;
SELECT * FROM Services;
SELECT * FROM Appointments;
SELECT * FROM HoaDon;
SELECT * FROM SanPham;
GO