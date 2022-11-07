-- Creates the login AbolrousHazem with password '340$Uuxwp7Mcxo7Khy'.  
CREATE LOGIN dbaAdmin   
    WITH PASSWORD = '340$Uuxwp7Mcxo7Khy';  
GO  

-- Creates a database user for the login created above.  
CREATE USER dbaAdmin FOR LOGIN dbaAdmin;  
GO  