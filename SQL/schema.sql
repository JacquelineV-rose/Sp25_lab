-- Create the database if it doesn't exist
CREATE DATABASE IF NOT EXISTS habittracker;
USE habittracker;

-- Create the users table
CREATE TABLE IF NOT EXISTS users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS habits (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    habit_name VARCHAR(100) NOT NULL,
    habit_description VARCHAR(255),
    habit_start_date DATE NOT NULL,
    habit_end_date DATE NOT NULL,
    habit_frequency VARCHAR(50) NOT NULL,
    habit_completed BOOLEAN NOT NULL DEFAULT FALSE,
    FOREIGN KEY (user_id) REFERENCES users(id)
);