CREATE TABLE Users 
(
    id        UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    fullname  VARCHAR(30)  NOT NULL,
    email     VARCHAR(100) NOT NULL,
    pass      VARCHAR(30)  NOT NULL,
    createdat DATETIME DEFAULT(GETDATE())
)