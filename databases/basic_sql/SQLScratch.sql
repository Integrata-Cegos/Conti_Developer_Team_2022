USE publishing
-- select au.id, ad.id from SAWITZKI_AUTHORS as au, SAWITZKI_ADDRESSES as ad where au.LASTNAME = 'Pausenkurt' and ad.city = 'Berlin'


-- select * from SAWITZKI_PUBLISHERS, SAWITZKI_BOOKS, SAWITZKI_AUTHORS;

-- SELECT * FROM SAWITZKI_PUBLISHERS AS PUB, SAWITZKI_BOOKS AS B, SAWITZKI_AUTHORS AS A
--	WHERE A.LASTNAME = 'PAUSENKURT' AND B.TITLE='Title3';
insert into SAWITZKI_PUBLISHERS values ('Addison-Wesley');
-- Rein didaktisches Beispiel, die Trefferzeile hat keine fachlich sinnvolle Bedeutung
SELECT PUB.NAME, B.PAGES, A.FIRSTNAME FROM SAWITZKI_PUBLISHERS AS PUB, SAWITZKI_BOOKS AS B, SAWITZKI_AUTHORS AS A
	WHERE A.LASTNAME = 'PAUSENKURT' AND B.TITLE='Title3';