drop table if exists ISSUES
drop table if exists USERS
create table Users (id int identity(1,1) primary key, username varchar(64) unique not null, lastname varchar(64) not null, firstname varchar(64) not null)
create table Issues (id int identity(1,1) primary key, description varchar(256), status tinyint check (status >= 0 and status <3) , priority tinyint check (priority >= 1 and priority <=4), assignee int, foreign key(assignee) references users(id))
alter table Issues add constraint check_status check (status = 0 or status = 2 or (status = 1 and assignee is not null ))

insert into users (username, lastname, firstname) values ('rs', 'Sawitzki', 'Rainer')
insert into users (username, lastname, firstname) values ('pp', 'Pausenkurt', 'Pascal')
insert into issues (description, status, priority) values ('Eat', 0, 2)
insert into issues (description, status, priority) values ('Sleep', 0, 2)
insert into issues (description, status, priority) values ('Drink', 0, 2)
insert into issues (description, status, priority) values ('Cook', 0, 2)
insert into issues (description, status, priority) values ('Clean', 0, 2)
update issues set assignee = (select id from Users where username='rs') where id = 1
update issues set assignee = (select id from Users where username='pp') where id = 2
update issues set assignee = (select id from Users where username='pp') where id = 3
update issues set assignee = (select id from Users where username='pp') where id = 4

update issues set status = 1 where id = 1
update issues set status = 2 where id = 1
update issues set status = 2 where id = 3

