use DB_IPPI

select*from IPPI_Utilisateur

select*from IPPI_Entreprise

select*from IPPI_Entreprise

select*from IPPI_superviseur

select*from IPPI_Utilisateur

select*from IPPI_superviseur  where id_superviseur<98 order by nom_superviseur

insert into IPPI_superviseur (id_superviseur, nom_superviseur) values('99','Tsunade')

set IDENTITY_INSERT IPPI_utilisateur on

delete from IPPI_ProduitUnite where id_produit = 157 

insert into IPPI_utilisateur (ID_utilisateur,Prenom, Nom, Mot_Passe, Identifiant, id_superviseur) values('17','Tsunade','Sinjou','A123','Admin','99')

select ID_utilisateur from IPPI_Utilisateur where Prenom= 'Tsunade' and Mot_Passe='A123' and Identifiant = 'Admin'