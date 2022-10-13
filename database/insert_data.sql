delete from Issues
delete from Users
insert into users (username, lastname, firstname) values ('rs', 'Sawitzki', 'Rainer')
insert into users (username, lastname, firstname) values ('pp', 'Pausenkurt', 'Pascal')
insert into issues (description, status, priority) values ('Eat', 0, 2)
insert into issues (description, status, priority) values ('Sleep', 0, 2)
insert into issues (description, status, priority) values ('Drink', 0, 2)
insert into issues (description, status, priority) values ('Cook', 0, 2)
update issues set assignee = (select id from Users where username='rs') where id = 1
update issues set assignee = (select id from Users where username='pp') where id = 2
update issues set assignee = (select id from Users where username='pp') where id = 3
update issues set assignee = (select id from Users where username='pp') where id = 4

update issues set status = 1 where id = 1
update issues set status = 2 where id = 1
update issues set status = 2 where id = 3

