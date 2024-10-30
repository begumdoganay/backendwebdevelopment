# Dvdrental Veritabanı Sorguları

Bu proje, Dvdrental örnek veritabanındaki film ve aktör verileri üzerinde bazı temel SQL sorgularını içermektedir. Aşağıda, kullanılan sorguların açıklamaları ve örnek verileri yer almaktadır.

## İçindekiler

- [Sorgular](#sorgular)
  - [1. Replacement Cost Sorgusu](#1-replacement-cost-sorgusu)
  - [2. Actor Sorgusu](#2-actor-sorgusu)
  - [3. Rental Rate ve Replacement Cost Sorgusu](#3-rental-rate-ve-replacement-cost-sorgusu)

## Sorgular

### 1. Replacement Cost Sorgusu

SELECT * 
FROM film 
WHERE replacement_cost BETWEEN 12.99 AND 16.99;
Açıklama:
Bu sorgu, film tablosundaki tüm sütunları getirir ve yalnızca replacement_cost değeri 12.99 ile 16.99 arasında olan filmleri seçer.

Örnek Veriler:

Film A: replacement_cost 12.99
Film B: replacement_cost 14.50
Film C: replacement_cost 16.00
Film D: replacement_cost 17.50
Sonuç:
Bu sorgu, Film A ve Film B'yi döndürecektir.

2. Actor Sorgusu

SELECT first_name, last_name 
FROM actor 
WHERE first_name IN ('Alice', 'Bob', 'Charlie');
Açıklama:
Bu sorgu, actor tablosundaki first_name ve last_name sütunlarını getirir; first_name değeri 'Alice', 'Bob' veya 'Charlie' olan aktörleri seçer.

Örnek Veriler:

Actor 1: first_name 'Alice', last_name 'Smith'
Actor 2: first_name 'David', last_name 'Johnson'
Actor 3: first_name 'Bob', last_name 'Williams'
Actor 4: first_name 'Charlie', last_name 'Brown'
Sonuç:
Bu sorgu, Actor 1 ve Actor 3'ü döndürecektir.

3. Rental Rate ve Replacement Cost Sorgusu


Copy
SELECT * 
FROM film 
WHERE rental_rate IN (1.99, 3.99, 5.99) 
AND replacement_cost IN (10.99, 20.99, 30.99);
Açıklama:
Bu sorgu, film tablosundaki tüm sütunları getirir; rental_rate değerinin 1.99, 3.99 veya 5.99 ve replacement_cost değerinin 10.99, 20.99 veya 30.99 olduğu filmleri seçer.

Örnek Veriler:

Film X: rental_rate 1.99, replacement_cost 10.99
Film Y: rental_rate 2.99, replacement_cost 20.99
Film Z: rental_rate 3.99, replacement_cost 25.99
Sonuç:
Bu sorgu, Film X ve Film Y'yi döndürecektir.

Kullanım
Bu sorguları bir SQL istemcisi veya veritabanı yönetim aracı kullanarak çalıştırabilirsiniz. Dvdrental veritabanını yükledikten sonra, sorguları çalıştırarak belirtilen verileri elde edebilirsiniz.

[Begüm DOĞANAY] - Proje oluşturucu
Lisans
Bu proje MIT Lisansı altında lisanslanmıştır.
