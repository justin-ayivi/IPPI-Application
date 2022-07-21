use DB_IPPI
delete from IPPI_CategorieProduit

set IDENTITY_INSERT IPPI_CategorieProduit ON

insert into IPPI_CategorieProduit (id_categorie, categorie) values ('1','CÉRÉALES ET PAINS'),
													('2','VIANDE'),
													('3','POISSON ET FRUITS DE MER'),
													('4','LAIT, FROMAGE ET OEUFS'),
													('5','HUILES ET GRAISSES'),
													('6','FRUITS'),
													('7','LÉGUMES'),
													('8','LEGUMINEUSES ET TUBERCULES'),
													('9','SUCRE, MIEL, CHOCOLAT ET CONFISERIE'),
													('10','EPICES, CONDIMENTS ET AUTRES'),
													('11','BOISSONS');
