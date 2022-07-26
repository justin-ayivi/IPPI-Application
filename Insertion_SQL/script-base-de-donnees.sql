USE [mabaseIPPI]
GO
/****** Object:  Table [dbo].[IPPI_CategorieProduit]    Script Date: 13/05/2021 02:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IPPI_CategorieProduit](
	[id_categorie] [int] IDENTITY(1,1) NOT NULL,
	[date_creation] [datetime] NOT NULL,
	[categorie] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_categorie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IPPI_Entreprise]    Script Date: 13/05/2021 02:17:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IPPI_Entreprise](
	[id_Entreprise] [int] IDENTITY(1,1) NOT NULL,
	[ninea] [varchar](1) NULL,
	[raison_soc] [varchar](50) NULL,
	[sigle] [varchar](50) NULL,
	[adresse] [varchar](50) NULL,
	[telephone] [int] NULL,
	[Date_creation] [datetime] NULL,
	[Date_modification] [datetime] NULL,
	[ID_utilisateur] [int] NULL,
	[id_produit] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Entreprise] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IPPI_infos_entreprise]    Script Date: 13/05/2021 02:17:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IPPI_infos_entreprise](
	[id_infos_entreprise] [int] NOT NULL,
	[nom_repondant] [varchar](50) NULL,
	[fonction_repondant] [varchar](50) NULL,
	[tel_repondant] [int] NULL,
	[email_repondant] [varchar](200) NULL,
	[id_Entreprise] [int] NULL,
 CONSTRAINT [PK_IPPI_infos_entreprise] PRIMARY KEY CLUSTERED 
(
	[id_infos_entreprise] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IPPI_infos_section]    Script Date: 13/05/2021 02:17:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IPPI_infos_section](
	[id_infos_section] [char](2) NOT NULL,
	[IPPI_Entreprise_id_Entreprise] [int] NOT NULL,
	[IPPI_section_id_section] [char](1) NOT NULL,
	[IPPI_unite_id_unite] [int] NOT NULL,
	[IPPI_Produit_id_produit] [int] NOT NULL,
	[nom_section] [varchar](20) NULL,
	[prix_val_vente] [float] NULL,
	[mois] [int] NULL,
	[annee] [int] NULL,
 CONSTRAINT [PK__IPPI_inf__9F33C864B3FC87A7] PRIMARY KEY CLUSTERED 
(
	[id_infos_section] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IPPI_INFOS_SECTION_F]    Script Date: 13/05/2021 02:17:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IPPI_INFOS_SECTION_F](
	[ID_INFOS_SECTION_F] [int] NOT NULL,
	[id_produit] [int] NULL,
	[nature_service] [varchar](50) NULL,
	[frequence_serv] [int] NULL,
	[existence_contrat] [nchar](10) NULL,
	[mois] [int] NULL,
	[annee] [int] NULL,
	[raison_soc] [varchar](50) NULL,
	[id_section] [char](1) NULL,
	[adresse] [varchar](50) NULL,
 CONSTRAINT [PK_IPPI_INFOS_SECTION_F] PRIMARY KEY CLUSTERED 
(
	[ID_INFOS_SECTION_F] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IPPI_Produit]    Script Date: 13/05/2021 02:17:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IPPI_Produit](
	[id_produit] [int] IDENTITY(1,1) NOT NULL,
	[nom_produit] [varchar](250) NULL,
	[date_creation] [datetime] NOT NULL,
	[id_categorie] [int] NULL,
 CONSTRAINT [PK__IPPI_Pro__BA39391B96C548D2] PRIMARY KEY CLUSTERED 
(
	[id_produit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IPPI_ProduitUnite]    Script Date: 13/05/2021 02:17:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IPPI_ProduitUnite](
	[id_produit] [int] IDENTITY(1,1) NOT NULL,
	[id_unite] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IPPI_section]    Script Date: 13/05/2021 02:17:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IPPI_section](
	[id_section] [char](1) NOT NULL,
	[nom_section] [varchar](50) NULL,
 CONSTRAINT [PK__IPPI_sec__83EAD1E892CFF0CD] PRIMARY KEY CLUSTERED 
(
	[id_section] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IPPI_superviseur]    Script Date: 13/05/2021 02:17:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IPPI_superviseur](
	[id_superviseur] [int] NOT NULL,
	[nom_superviseur] [varchar](50) NULL,
 CONSTRAINT [PK_IPPI_superviseur] PRIMARY KEY CLUSTERED 
(
	[id_superviseur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IPPI_unite]    Script Date: 13/05/2021 02:17:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IPPI_unite](
	[id_unite] [int] IDENTITY(1,1) NOT NULL,
	[unite] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_unite] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IPPI_Utilisateur]    Script Date: 13/05/2021 02:17:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IPPI_Utilisateur](
	[ID_utilisateur] [int] IDENTITY(1,1) NOT NULL,
	[Prenom] [varchar](50) NULL,
	[Nom] [varchar](50) NULL,
	[Mot_Passe] [varchar](50) NULL,
	[Identifiant] [varchar](50) NULL,
	[id_superviseur] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_utilisateur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IPPI_CategorieProduit] ADD  CONSTRAINT [DF_CategorieProduit_date_creation]  DEFAULT (getdate()) FOR [date_creation]
GO
ALTER TABLE [dbo].[IPPI_Entreprise]  WITH CHECK ADD FOREIGN KEY([ID_utilisateur])
REFERENCES [dbo].[IPPI_Utilisateur] ([ID_utilisateur])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IPPI_Entreprise]  WITH CHECK ADD  CONSTRAINT [FK_IPPI_Entreprise_IPPI_Produit] FOREIGN KEY([id_produit])
REFERENCES [dbo].[IPPI_Produit] ([id_produit])
GO
ALTER TABLE [dbo].[IPPI_Entreprise] CHECK CONSTRAINT [FK_IPPI_Entreprise_IPPI_Produit]
GO
ALTER TABLE [dbo].[IPPI_infos_entreprise]  WITH CHECK ADD  CONSTRAINT [FK_IPPI_infos_entreprise_IPPI_Entreprise] FOREIGN KEY([id_Entreprise])
REFERENCES [dbo].[IPPI_Entreprise] ([id_Entreprise])
GO
ALTER TABLE [dbo].[IPPI_infos_entreprise] CHECK CONSTRAINT [FK_IPPI_infos_entreprise_IPPI_Entreprise]
GO
ALTER TABLE [dbo].[IPPI_infos_section]  WITH CHECK ADD  CONSTRAINT [FK__IPPI_info__IPPI___4222D4EF] FOREIGN KEY([IPPI_Produit_id_produit])
REFERENCES [dbo].[IPPI_Produit] ([id_produit])
GO
ALTER TABLE [dbo].[IPPI_infos_section] CHECK CONSTRAINT [FK__IPPI_info__IPPI___4222D4EF]
GO
ALTER TABLE [dbo].[IPPI_infos_section]  WITH CHECK ADD  CONSTRAINT [FK__IPPI_info__IPPI___4316F928] FOREIGN KEY([IPPI_unite_id_unite])
REFERENCES [dbo].[IPPI_unite] ([id_unite])
GO
ALTER TABLE [dbo].[IPPI_infos_section] CHECK CONSTRAINT [FK__IPPI_info__IPPI___4316F928]
GO
ALTER TABLE [dbo].[IPPI_infos_section]  WITH CHECK ADD  CONSTRAINT [FK__IPPI_info__IPPI___440B1D61] FOREIGN KEY([IPPI_section_id_section])
REFERENCES [dbo].[IPPI_section] ([id_section])
GO
ALTER TABLE [dbo].[IPPI_infos_section] CHECK CONSTRAINT [FK__IPPI_info__IPPI___440B1D61]
GO
ALTER TABLE [dbo].[IPPI_infos_section]  WITH CHECK ADD  CONSTRAINT [FK__IPPI_info__IPPI___44FF419A] FOREIGN KEY([IPPI_Entreprise_id_Entreprise])
REFERENCES [dbo].[IPPI_Entreprise] ([id_Entreprise])
GO
ALTER TABLE [dbo].[IPPI_infos_section] CHECK CONSTRAINT [FK__IPPI_info__IPPI___44FF419A]
GO
ALTER TABLE [dbo].[IPPI_INFOS_SECTION_F]  WITH CHECK ADD  CONSTRAINT [FK_IPPI_INFOS_SECTION_F_IPPI_Produit] FOREIGN KEY([id_produit])
REFERENCES [dbo].[IPPI_Produit] ([id_produit])
GO
ALTER TABLE [dbo].[IPPI_INFOS_SECTION_F] CHECK CONSTRAINT [FK_IPPI_INFOS_SECTION_F_IPPI_Produit]
GO
ALTER TABLE [dbo].[IPPI_INFOS_SECTION_F]  WITH CHECK ADD  CONSTRAINT [FK_IPPI_INFOS_SECTION_F_IPPI_section] FOREIGN KEY([id_section])
REFERENCES [dbo].[IPPI_section] ([id_section])
GO
ALTER TABLE [dbo].[IPPI_INFOS_SECTION_F] CHECK CONSTRAINT [FK_IPPI_INFOS_SECTION_F_IPPI_section]
GO
ALTER TABLE [dbo].[IPPI_Produit]  WITH CHECK ADD  CONSTRAINT [FK_IPPI_Produit_IPPI_CategorieProduit] FOREIGN KEY([id_categorie])
REFERENCES [dbo].[IPPI_CategorieProduit] ([id_categorie])
GO
ALTER TABLE [dbo].[IPPI_Produit] CHECK CONSTRAINT [FK_IPPI_Produit_IPPI_CategorieProduit]
GO
ALTER TABLE [dbo].[IPPI_ProduitUnite]  WITH CHECK ADD  CONSTRAINT [FK__IPPI_Prod__id_pr__5165187F] FOREIGN KEY([id_produit])
REFERENCES [dbo].[IPPI_Produit] ([id_produit])
GO
ALTER TABLE [dbo].[IPPI_ProduitUnite] CHECK CONSTRAINT [FK__IPPI_Prod__id_pr__5165187F]
GO
ALTER TABLE [dbo].[IPPI_ProduitUnite]  WITH CHECK ADD FOREIGN KEY([id_unite])
REFERENCES [dbo].[IPPI_unite] ([id_unite])
GO
ALTER TABLE [dbo].[IPPI_Utilisateur]  WITH CHECK ADD  CONSTRAINT [FK_IPPI_Utilisateur_IPPI_superviseur] FOREIGN KEY([id_superviseur])
REFERENCES [dbo].[IPPI_superviseur] ([id_superviseur])
GO
ALTER TABLE [dbo].[IPPI_Utilisateur] CHECK CONSTRAINT [FK_IPPI_Utilisateur_IPPI_superviseur]
GO
