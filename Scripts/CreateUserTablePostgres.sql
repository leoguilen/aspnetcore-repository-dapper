CREATE TABLE Users 
(
    id        UUID PRIMARY KEY NOT NULL,
    fullname  VARCHAR(30)  NOT NULL,
    email     VARCHAR(100) NOT NULL,
    pass      VARCHAR(30)  NOT NULL,
    createdAt TIMESTAMP
)