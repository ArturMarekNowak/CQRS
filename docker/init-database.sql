CREATE DATABASE users;

CREATE USER replicator WITH REPLICATION ENCRYPTED PASSWORD 'replicator_password';
SELECT pg_create_physical_replication_slot('replication_slot');


CREATE USER ro_user WITH PASSWORD 'qwerty';
CREATE USER rw_user WITH PASSWORD 'qwerty';
GRANT ALL PRIVILEGES ON DATABASE users TO rw_user;
GRANT SELECT ON DATABASE users TO ro_user;


    
