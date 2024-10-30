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