USE DB_IPPI
select * from IPPI_utilisateur

delete from IPPI_Utilisateur

SET IDENTITY_INSERT IPPI_Utilisateur on

insert into IPPI_utilisateur (ID_utilisateur,Prenom, Nom, Mot_Passe, Identifiant, id_superviseur) values('1','Kakashi','Hatake','g101','Superviseur','1')
insert into IPPI_utilisateur (ID_utilisateur,Prenom, Nom, Mot_Passe, Identifiant, id_superviseur) values('2','Naruto','Uzumaki','g102','Agent','1')
insert into IPPI_utilisateur (ID_utilisateur,Prenom, Nom, Mot_Passe, Identifiant, id_superviseur) values('3','Sakura','Haruno','g103','Agent','1')
insert into IPPI_utilisateur (ID_utilisateur,Prenom, Nom, Mot_Passe, Identifiant, id_superviseur) values('4','Sasuke','Uchiwa','g104','Agent','1')
insert into IPPI_utilisateur (ID_utilisateur,Prenom, Nom, Mot_Passe, Identifiant, id_superviseur) values('5','Asuma','Sarutobi','g201','Superviseur','2')
insert into IPPI_utilisateur (ID_utilisateur,Prenom, Nom, Mot_Passe, Identifiant, id_superviseur) values('6','Choji','Akimichi','g202','Agent','2')
insert into IPPI_utilisateur (ID_utilisateur,Prenom, Nom, Mot_Passe, Identifiant, id_superviseur) values('7','Ino','Yamanaka','g203','Agent','2')
insert into IPPI_utilisateur (ID_utilisateur,Prenom, Nom, Mot_Passe, Identifiant, id_superviseur) values('8','Shikamaru','Nara','g204','Agent','2')
insert into IPPI_utilisateur (ID_utilisateur,Prenom, Nom, Mot_Passe, Identifiant, id_superviseur) values('9','Kurenai','Yuhi','g301','Superviseur','3')
insert into IPPI_utilisateur (ID_utilisateur,Prenom, Nom, Mot_Passe, Identifiant, id_superviseur) values('10','Hinata','Hyuga','g302','Agent','3')
insert into IPPI_utilisateur (ID_utilisateur,Prenom, Nom, Mot_Passe, Identifiant, id_superviseur) values('11','Kiba','Inuzuka','g303','Agent','3')
insert into IPPI_utilisateur (ID_utilisateur,Prenom, Nom, Mot_Passe, Identifiant, id_superviseur) values('12','Shino','Aburame','g304','Agent','3')
insert into IPPI_utilisateur (ID_utilisateur,Prenom, Nom, Mot_Passe, Identifiant, id_superviseur) values('13','Tsunade','Sinjou','A123','Admin','99')
insert into IPPI_utilisateur (ID_utilisateur,Prenom, Nom, Mot_Passe, Identifiant, id_superviseur) values('14','Diop','Mamadou','g305','Agent','3')
insert into IPPI_utilisateur (ID_utilisateur,Prenom, Nom, Mot_Passe, Identifiant, id_superviseur) values('15','Diop','Mamadou','g205','Agent','2')

SET IDENTITY_INSERT IPPI_Utilisateur off

