CREATE TABLE Users 
(
    Id        UUID PRIMARY KEY NOT NULL,
    FullName  VARCHAR(30)  NOT NULL,
    Email     VARCHAR(100) NOT NULL,
    Pass      VARCHAR(30)  NOT NULL,
    CreatedAt TIMESTAMP
)