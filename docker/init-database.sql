CREATE DATABASE users;
GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO PUBLIC;
    
CREATE USER replicator WITH REPLICATION ENCRYPTED PASSWORD 'replicator_password';
SELECT pg_create_physical_replication_slot('replication_slot');

CREATE USER rw_user WITH PASSWORD 'qwerty';
CREATE USER ro_user WITH PASSWORD 'qwerty';
GRANT rw_user TO ro_user;