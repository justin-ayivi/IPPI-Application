

select distinct sigle from IPPI_entreprise 

select*from IPPI_entreprise

select*from IPPI_Produit

select*from IPPI_ProduitUnite

select*from IPPI_CategorieProduit
--- jointure entre les tables produit et entreprise 

select IPPI_Entreprise.id_produit, Nom_produit from IPPI_Entreprise inner join IPPI_Produit on IPPI_Produit.id_produit = IPPI_Entreprise.id_produit

select IPPI_ProduitUnite.id_unite, IPPI_Unite.unite from IPPI_ProduitUnite INNER JOIN IPPI_Unite on IPPI_ProduitUnite.id_unite = IPPI_Unite.id_unite where id_produit=5

---- jointure table produit  et table unite 

select id_produit, Nom_produit, IPPI_CategorieProduit.id_categorie, categorie from IPPI_Produit inner join IPPI_CategorieProduit on IPPI_Produit.id_categorie = IPPI_CategorieProduit.id_categorie order by id_produit desc

select * from IPPI_infos_section
