use DB_IPPI

select * from IPPI_superviseur order by nom_superviseur

select*from IPPI_CategorieProduit order by categorie

delete from IPPI_Utilisateur where ID_utilisateur=2008

delete from IPPI_superviseur where id_superviseur = 99


select* from IPPI_Utilisateur where id_superviseur = 99

select*from IPPI_superviseur

set IDENTITY_INSERT IPPI_Utilisateur ON; 

insert into IPPI_utilisateur (ID_utilisateur,Prenom, Nom, Mot_Passe, Identifiant, id_superviseur) values('16','Hinatamkml','Hyugasfs','g302','Agent','3')

delete from IPPI_Utilisateur

insert into IPPI_utilisateur (ID_utilisateur,Prenom, Nom, Mot_Passe, Identifiant, id_superviseur) values('1','Kakashi','Hatake','g101','Superviseur','1')
