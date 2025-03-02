-- Create the database if it doesn't exist
CREATE DATABASE IF NOT EXISTS habittracker;
USE habittracker;

-- Create the users table
CREATE TABLE IF NOT EXISTS users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE
);