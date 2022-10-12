insert into users (username, lastname, firstname) values ('rs', 'Sawitzki', 'Rainer')
insert into users (username, lastname, firstname) values ('pp', 'Pausenkurt', 'Pascal')
insert into issues (description, status, priority) values ('Eat', 0, 2)
insert into issues (description, status, priority) values ('Sleep', 0, 2)
insert into issues (description, status, priority) values ('Drink', 0, 2)
update issues set assignee = (select id from users where username='rs') where id = 1
update issues set assignee = (select id from users where username='pp') where id = 2
update issues set status = 1 where id = 1
update issues set status = 2 where id = 1
update issues set status = 2 where id = 3

