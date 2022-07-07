--drop schema ERS_P1;
--drop table ERS_P1.users;
--drop table ERS_P1.tickets;

create schema ERS_P1;

create table ERS_P1.users(
	id int identity,
	username varchar(100) not null,
	password varchar(100) not null,
	role VARCHAR(10) NOT NULL CHECK (role IN('Manager', 'Employee')),
	primary key(id)
);

create table ERS_P1.tickets(
	id int identity,
	reason varchar(100) not null,
	status VARCHAR(10) NOT NULL CHECK (status IN('Pending', 'Approved', 'Denied')),
	authorID int foreign key references ERS_P1.users(id) not null,
	resolverID int foreign key references ERS_P1.users(id) not null,
	amount DECIMAL not null,
	primary key(id)
);

INSERT into ERS_P1.users (username, password, role) values ('sampleManager', 'ManagerPass', 'Manager');
INSERT into ERS_P1.users (username, password, role) values ('sampleEmployee', 'EmployeePass', 'Employee');

select * from ERS_P1.users; 
select username from ERS_P1.users;
select * from ERS_P1.users where username = 'sampleManager' and password = 'ManagerPass'; -- this is usefull for checking matching passwords and usernames