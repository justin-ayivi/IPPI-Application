

--------- RESTITUTION  QU ON METTRA ENSUITE DANS UNE VUE -----------

---- jointure table produit  et table unite 

create view v_RestitionExcel
as

select IPPI_Utilisateur.id_superviseur as [CODE SUPERVISEUR] , IPPI_Entreprise.ID_utilisateur as [CODE UTILISATEUR], id_Entreprise as [N ENTR], raison_soc as [RAISON SOCIALE], sigle as [SIGLE], 
	 categorie as [LIBELLE GAMME], nom_produit as [LIBELLE PRODUIT], IPPI_unite.unite as [LIBELLE UNITE], 
	 IPPI_infos_section.mois as [MOIS], IPPI_infos_section.annee as [ANNEE], 
	 IPPI_infos_section.prix_val_vente as [PRIXVENTE]
	 from IPPI_Entreprise
	 inner join IPPI_infos_section on IPPI_infos_section.IPPI_Produit_id_produit = IPPI_Entreprise.id_produit
	 inner join IPPI_unite on IPPI_infos_section.IPPI_unite_id_unite = IPPI_unite.id_unite
	 inner join IPPI_Utilisateur on  IPPI_Utilisateur.ID_utilisateur = IPPI_Entreprise.ID_utilisateur
	 inner join IPPI_Produit on IPPI_Entreprise.id_produit = IPPI_Produit.id_produit
	 join IPPI_CategorieProduit on IPPI_Produit.id_categorie = IPPI_CategorieProduit.id_categorie

