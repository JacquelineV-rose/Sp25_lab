USE habittracker;

-- Insert sample users
INSERT INTO users (username, email) VALUES 
('meghan', 'meghan@example.com'),
('john_doe', 'johndoe@example.com'),
('jane_doe', 'janedoe@example.com')
ON DUPLICATE KEY UPDATE username=VALUES(username), email=VALUES(email);