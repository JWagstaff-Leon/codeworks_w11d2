CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS contractors(
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL
) DEFAULT CHARSET UTF8;

CREATE TABLE IF NOT EXISTS companies(
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL
) DEFAULT CHARSET UTF8;

CREATE TABLE IF NOT EXISTS jobs(
    id INT AUTO_INCREMENT PRIMARY KEY,
    contractorId INT NOT NULL,
    companyId INT NOT NULL,

    FOREIGN KEY (contractorId) REFERENCES contractors(id) ON DELETE CASCADE,
    FOREIGN KEY (companyId) REFERENCES jobs(id) ON DELETE CASCADE
) DEFAULT CHARSET UTF8;