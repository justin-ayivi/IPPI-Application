-- trigger pour unicite login
use DB_IPPI

CREATE TRIGGER check_user
on IPPI_Utilisateur
after UPDATE, INSERT
as
begin
 if (select count(*) as numligneUser from IPPI_Utilisateur, inserted where IPPI_Utilisateur.Prenom=inserted.Prenom)>1
	begin
		 print('Utilisateur  existe déja')
		 rollback
	end
end


------------------------------------

