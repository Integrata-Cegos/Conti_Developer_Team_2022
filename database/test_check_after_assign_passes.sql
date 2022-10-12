update issues set assignee = (select id from users where username='pp') where id = 3
update issues set status = 1 where id = 3

