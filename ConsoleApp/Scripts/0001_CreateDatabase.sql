IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'IOmundoDb')
  BEGIN
    CREATE DATABASE [IOmundoDb]
  END
  GO

USE [IOmundoDb]
 GO