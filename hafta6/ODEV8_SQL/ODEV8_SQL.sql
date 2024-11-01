-- 1. Employee Tablosunu Oluşturma
CREATE TABLE employee (
    id INTEGER PRIMARY KEY,  -- Çalışan ID'si
    name VARCHAR(50),        -- Çalışan adı
    birthday DATE,          -- Doğum tarihi
    email VARCHAR(100)      -- E-posta adresi
);

-- 2. Mockaroo ile Veri Ekleme
-- (Bu adım, Mockaroo'dan indirdiğiniz CSV dosyasını kullanarak verileri eklemek içindir.)
-- Aşağıdaki örnek, veri tabanınıza uygun bir LOAD DATA komutudur:
LOAD DATA INFILE 'path_to_your_file.csv'
INTO TABLE employee
FIELDS TERMINATED BY ',' 
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
IGNORE 1 ROWS;  -- Başlık satırını atlamak için

-- 3. UPDATE İşlemleri
/*
UPDATE employee SET name = 'John Doe' WHERE id = 1;
UPDATE employee SET birthday = '1990-05-15' WHERE id = 2;
UPDATE employee SET email = 'jane@example.com' WHERE id = 3;
UPDATE employee SET name = 'Alice Smith' WHERE id = 4;
UPDATE employee SET birthday = '1985-12-01' WHERE id = 5;

-- 4. DELETE İşlemleri
DELETE FROM employee WHERE id = 1;
DELETE FROM employee WHERE id = 2;
DELETE FROM employee WHERE id = 3;
DELETE FROM employee WHERE id = 4;
DELETE FROM employee WHERE id = 5;

-- 3. UPDATE İşlemleri
UPDATE employee SET name = 'John Doe' WHERE name LIKE 'J%';  -- 'J' ile başlayan tüm isimleri güncelle
UPDATE employee SET birthday = '1990-05-15' WHERE birthday BETWEEN '1985-01-01' AND '1995-12-31';  -- Belirli bir tarih aralığındaki doğum tarihlerini güncelle
UPDATE employee SET email = 'jane@example.com' WHERE id LIKE '3';  -- ID'si 3 olanı güncelle
UPDATE employee SET name = 'Alice Smith' WHERE name LIKE 'A%';  -- 'A' ile başlayan tüm isimleri güncelle
UPDATE employee SET birthday = '1985-12-01' WHERE birthday BETWEEN '1980-01-01' AND '1990-12-31';  -- Başka bir tarih aralığındaki doğum tarihlerini güncelle

-- 4. DELETE İşlemleri
DELETE FROM employee WHERE id BETWEEN 1 AND 5;  -- ID'si 1 ile 5 arasındaki tüm kayıtları sil
DELETE FROM employee WHERE name LIKE 'John%';  -- 'John' ile başlayan tüm isimleri sil
DELETE FROM employee WHERE email LIKE '%example.com';  -- 'example.com' ile biten tüm e-posta adreslerini sil
*/
