use DB_IPPI

select*from IPPI_Entreprise

delete from IPPI_Entreprise

set IDENTITY_INSERT IPPI_Entreprise OFF

set IDENTITY_INSERT IPPI_Entreprise On 

insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('1','1','ENTREPISE1','ENT1','dakar','77 000 00 01')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('2','0','ENTREPISE2','ENT2','medina','77 000 00 02')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('3','1','ENTREPISE3','ENT3','colobane','77 000 00 03')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('4','0','ENTREPISE4','ENT4','pikine','77 000 00 04')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('5','0','ENTREPISE5','ENT5','fass','77 000 00 05')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('6','1','ENTREPISE6','ENT6','hlm5','77 000 00 06')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('7','0','ENTREPISE7','ENT7','medine','77 000 00 07')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('8','1','ENTREPISE8','ENT8','fan','77 000 00 08')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('9','1','ENTREPISE9','ENT9','han','77 000 00 09')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('10','1','ENTREPISE10','ENT10','mermoz','77 000 00 010')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('11','1','ENTREPISE11','ENT11','ouakam','77 000 00 011')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('12','1','ENTREPISE12','ENT12','dior','77 000 00 012')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('13','1','ENTREPISE13','ENT13','yoff','77 000 00 013')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('14','1','ENTREPISE14','ENT14','liberte6','77 000 00 014')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('15','1','ENTREPISE15','ENT15','castor','77 000 00 015')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('16','1','ENTREPISE16','ENT16','bourguiba','77 000 00 016')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('17','1','ENTREPISE17','ENT17','rufisque','77 000 00 017')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('18','0','ENTREPISE18','ENT18','diamniadjo','77 000 00 018')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('19','1','ENTREPISE19','ENT19','dakar','77 000 00 019')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('20','0','ENTREPISE20','ENT20','grand dakar','77 000 00 020')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('21','1','ENTREPISE21','ENT21','fass','77 000 00 021')
insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('22','1','ENTREPISE22','ENT22','point e','77 000 00 022')

insert into IPPI_Entreprise (id_Entreprise,ninea, raison_soc, sigle,adresse, telephone) values('23','1','ENTREPISE23','ENT23','point eDD','77 000 00 025')

set IDENTITY_INSERT IPPI_Entreprise OFF

select*from IPPI_Entreprise

select*from IPPI_Utilisateur

update IPPI_Entreprise set ID_utilisateur=3 where sigle = 'ENT23'