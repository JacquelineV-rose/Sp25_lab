#!/bin/zsh
echo "Setting up MySQL database..."

# Run SQL commands
mysql -u root -p < sql/schema.sql
mysql -u root -p < sql/seed.sql

echo "Database setup complete!"