## This is the PostgreSQL script to create both the database and the table.
```sql
-- Database: CarlosDB

-- DROP DATABASE IF EXISTS "CarlosDB";

CREATE DATABASE "CarlosDB"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'English_Canada.1252'
    LC_CTYPE = 'English_Canada.1252'
    LOCALE_PROVIDER = 'libc'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
	
CREATE TABLE customers (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255),
    last_name VARCHAR(255),
    government_id VARCHAR(255) UNIQUE,
    age INTEGER,
    sex CHAR(1),
    tel VARCHAR(20),
    email VARCHAR(255) UNIQUE
);
```
