-- *********************************************
-- * Standard SQL generation                   
-- *--------------------------------------------
-- * DB-MAIN version: 10.0.3              
-- * Generator date: Aug 17 2017              
-- * Generation date: Tue May 22 17:03:47 2018 
-- * LUN file: C:\Users\Bisa\source\repos\SEP\PROJECT.lun 
-- * Schema: SCHEMA_TRASFORMATO/SQL 
-- ********************************************* 


-- Database Section
-- ________________ 


-- DBSpace Section
-- _______________


-- Tables Section
-- _____________ 

create table APPUNTAMENTICON (
     IDUTENTE varchar(10) not null,
     IDAPPUNTAMENTO varchar(10) not null,
     IDINTERMEDIARIO varchar(10) not null,
     IDCLIENTE varchar(10) not null,
     IDESTERNO varchar(10) not null,
     constraint ID_APPUNTAMENTICON_ID primary key (IDUTENTE, IDAPPUNTAMENTO, IDINTERMEDIARIO, IDCLIENTE, IDESTERNO));

create table APPUNTAMENTO (
     IDUTENTE varchar(10) not null,
     IDAPPUNTAMENTO varchar(10) not null,
     DATA date not null,
     ORA time not null,
     LUOGO varchar(100) not null,
     NOTE blob,
     constraint ID_APPUNTAMENTO_ID primary key (IDUTENTE, IDAPPUNTAMENTO));

create table CLIENTE (
     IDUTENTE varchar(10) not null,
     IDCLIENTE varchar(10) not null,
     TIPO enum('A', 'E', 'P') not null,
     IDPERSONA varchar(10) not null,
	 NOTE blob,
     constraint ID_CLIENTE_ID primary key (IDUTENTE, IDCLIENTE));

create table DATORE_LAVORO (
     IDDATORELAVORO varchar(10) not null,
     NOME varchar(50) not null,
     COGNOME varchar(50) not null,
     RAGIONE_SOCIALE varchar(100) not null,
     PIVA varchar(20) not null,
     CF varchar(20) not null,
     TELEFONO varchar(20) not null,
     INDIRIZZO varchar(100) not null,
     MAIL varchar(50),
     IDUTENTE varchar(10) not null,
     constraint ID_DATORE_LAVORO_ID primary key (IDDATORELAVORO));

create table ESTERNO (
     IDUTENTE varchar(10) not null,
     IDESTERNO varchar(10) not null,
     NOME varchar(50) not null,
     COGNOME varchar(50),
     PIVA varchar(20),
     CF varchar(20),
     TELEFONO varchar(20),
     MAIL varchar(50),
     INDIRIZZO varchar(100),
     constraint ID_ESTERNO_ID primary key (IDUTENTE, IDESTERNO));

create table FATTURA (
     IDUTENTE varchar(10) not null,
     ANNO int not null,
     NUMERO int not null,
     DATA date not null,
     BASE_IMPONIBILE decimal(9,2) not null,
     SCONTO decimal(9,2) not null,
     TOTALE decimal(9,2) not null,
     TIPOAGENTE enum('S'),
     IDDATORELAVORO varchar(10),
     IDCLIENTE varchar(10),
     constraint ID_FATTURA_ID primary key (IDUTENTE, ANNO, NUMERO));

create table INTERMEDIARIO (
     IDUTENTE varchar(10) not null,
     IDINTERMEDIARIO varchar(10) not null,
     IDPERSONA varchar(10) not null,
     constraint ID_INTERMEDIARIO_ID primary key (IDUTENTE, IDINTERMEDIARIO));

create table MAIL (
     IDUTENTE varchar(10) not null,
     IDPERSONA varchar(10) not null,
     MAIL varchar(50) not null,
     NOTA blob,
     constraint ID_MAIL_ID primary key (MAIL, IDUTENTE, IDPERSONA));

create table MAILINVIATA (
     IDUTENTE varchar(10) not null,
     IDMAIL varchar(10) not null,
     MAIL varchar(50) not null,
     DATA date not null,
     OGGETTO varchar(100) not null,
     CORPO blob not null,
     IDPERSONA varchar(10) not null,
     constraint ID_MAIL_INVIATA_ID primary key (IDUTENTE, IDMAIL));

create table PERSONA (
     IDUTENTE varchar(10) not null,
     IDPERSONA varchar(10) not null,
     CF varchar(20) not null,
     INDIRIZZO varchar(100) not null,
     TIPO enum('F','G') not null,
     NOME varchar(50),
     COGNOME varchar(50),
     PIVA varchar(20),
     RAGIONE_SOCIALE varchar(100),
     SEDE_LEGALE varchar(100),
     constraint SID_PERSONA_ID unique (IDUTENTE, CF),
     constraint ID_PERSONA_ID primary key (IDUTENTE, IDPERSONA));

create table PREVENTIVO (
     IDUTENTE varchar(10) not null,
     IDPREVENTIVO varchar(10) not null,
     DATA date not null,
     TOTALE decimal(9,2) not null,
     ACCETTATO bool not null,
     IDCLIENTE varchar(10) not null,
     constraint ID_PREVENTIVO_ID primary key (IDUTENTE, IDPREVENTIVO));

create table REFERENTE (
     IDUTENTE varchar(10) not null,
     IDCLIENTE varchar(10) not null,
     NOME varchar(50) not null,
     NOTA blob,
     constraint ID_REFERENTE_ID primary key (NOME, IDUTENTE, IDCLIENTE));

create table TELEFONO (
     IDUTENTE varchar(10) not null,
     IDPERSONA varchar(10) not null,
     TELEFONO varchar(50) not null,
     NOTA blob,
     constraint ID_TELEFONO_ID primary key (TELEFONO, IDUTENTE, IDPERSONA));

create table UTENTE (
     IDUTENTE varchar(10) not null,
     USERNAME varchar(50) not null,
     PASSWORD varchar(50) not null,
     PIVA varchar(20) not null,
     CF varchar(20) not null,
     TELEFONO varchar(50) not null,
     INDIRIZZO varchar(100) not null,
     MAIL varchar(50) not null,
     TIPO enum('AZ','LP','AG') not null,
     NOME varchar(50),
     COGNOME varchar(50),
     PROVVIGIONE_DEFAULT decimal(3,2),
     RAGIONE_SOCIALE varchar(100),
     SEDE_LEGALE varchar(100),
     constraint SID_UTENTE_ID unique (USERNAME),
     constraint ID_UTENTE_ID primary key (IDUTENTE));

create table VENDITA (
     IDUTENTE varchar(10) not null,
     IDVENDITA varchar(100) not null,
     IDPREVENTIVO varchar(10),
     TOTALE decimal(9,2) not null,
     TIPOAGENTE enum('S'),
     PROVVIGIONE decimal(3,2),
     IDCLIENTE varchar(10) not null,
     constraint ID_VENDITA_ID primary key (IDUTENTE, IDVENDITA));

create table VENDITEFATTURA (
     ANNO int not null,
     NUMERO int not null,
     IDUTENTE varchar(10) not null,
     IDVENDITA varchar(10) not null,
     constraint ID_VENDITEFATTURA_ID primary key (ANNO, NUMERO, IDUTENTE, IDVENDITA));

create table VOCEFATTURA (
     IDUTENTE varchar(10) not null,
     ANNO int not null,
     NUMEROFATTURA int not null,
     NUMEROVOCE int not null,
     DESCRIZIONE varchar(100) not null,
     TIPOLOGIA varchar(20) not null, ---------------------------------------------<<<<< CHECK
     PERCENTUALE_IVA decimal(3,2) not null,
     QUANTITA int not null,
     IMPORTO decimal(9,2) not null,
     constraint ID_VOCEFATTURA_ID primary key (NUMEROVOCE, IDUTENTE, ANNO, NUMEROFATTURA));

create table VOCEVENDITA (
     IDUTENTE varchar(10) not null,
     IDVENDITA varchar(10) not null,
     NUMERO int not null,
     DESCRIZIONE varchar(100) not null,
     TIPOLOGIA varchar(20) not null, ---------------------------------------------<<<<< CHECK
     QUANTITA int not null,
     PROVVIGIONE decimal(3,2),
     IMPORTO decimal(9,2) not null,
     constraint ID_VOCEVENDITA_ID primary key (NUMERO, IDUTENTE, IDVENDITA));

create table VOCIPREVENTIVO (
     IDUTENTE varchar(10) not null,
     IDPREVENTIVO varchar(10) not null,
     NUMERO int not null,
     DESCRIZIONE varchar(100) not null,
     TIPOLOGIA varchar(20) not null, ---------------------------------------------<<<<< CHECK
     QUANTITA int not null,
     IMPORTO decimal(9,2) not null,
     constraint ID_VOCIPREVENTIVO_ID primary key (NUMERO, IDUTENTE, IDPREVENTIVO));


-- Constraints Section
-- ___________________ 

alter table APPUNTAMENTICON add constraint REF_APPUN_APPUN
     foreign key (IDUTENTE, IDAPPUNTAMENTO)
     references APPUNTAMENTO(IDUTENTE, IDAPPUNTAMENTO);

alter table APPUNTAMENTICON add constraint REF_APPUN_INTER_FK
     foreign key (IDUTENTE, IDINTERMEDIARIO)
     references INTERMEDIARIO(IDUTENTE, IDINTERMEDIARIO);

alter table APPUNTAMENTICON add constraint REF_APPUN_CLIEN_FK
     foreign key (IDUTENTE, IDCLIENTE)
     references CLIENTE(IDUTENTE, IDCLIENTE);

alter table APPUNTAMENTICON add constraint REF_APPUN_ESTER_FK
     foreign key (IDUTENTE, IDESTERNO)
     references ESTERNO(IDUTENTE, IDESTERNO);

alter table APPUNTAMENTO add constraint REF_APPUN_UTENT
     foreign key (IDUTENTE)
     references UTENTE(IDUTENTE);

alter table CLIENTE add constraint REF_CLIEN_UTENT
     foreign key (IDUTENTE)
     references UTENTE(IDUTENTE);

alter table CLIENTE add constraint REF_CLIEN_PERSO_FK
     foreign key (IDUTENTE, IDPERSONA)
     references PERSONA (IDUTENTE, CF);

alter table DATORE_LAVORO add constraint EQU_DATOR_UTENT_FK
     foreign key (IDUTENTE)
     references UTENTE(IDUTENTE);

alter table ESTERNO add constraint REF_ESTER_UTENT
     foreign key (IDUTENTE)
     references UTENTE(IDUTENTE);

alter table FATTURA add constraint REF_FATTU_DATOR_FK
     foreign key (IDDATORELAVORO)
     references DATORE_LAVORO(IDDATORELAVORO);

alter table FATTURA add constraint COEX_FATTURA
     check((TIPOAGENTE is not null and IDDATORELAVORO is not null)
           or (TIPOAGENTE is null and IDDATORELAVORO is null)); 

alter table FATTURA add constraint REF_FATTU_UTENT
     foreign key (IDUTENTE)
     references UTENTE(IDUTENTE);

alter table FATTURA add constraint EXCL_FATTURA
     check((TIPOAGENTE is not null and IDCLIENTE is null)
           or (TIPOAGENTE is null and IDCLIENTE is not null)
           or (TIPOAGENTE is null and IDCLIENTE is null)); 

alter table INTERMEDIARIO add constraint REF_INTER_PERSO_FK
     foreign key (IDUTENTE, IDPERSONA)
     references PERSONA (IDUTENTE, CF);

alter table MAIL add constraint REF_MAIL_PERSO_FK
     foreign key (IDUTENTE, IDPERSONA)
     references PERSONA(IDUTENTE, IDPERSONA);

alter table MAILINVIATA add constraint REF_MAIL__UTENT
     foreign key (IDUTENTE)
     references UTENTE(IDUTENTE);

alter table MAILINVIATA add constraint REF_MAIL__PERSO_FK
     foreign key (IDUTENTE, IDPERSONA)
     references PERSONA (IDUTENTE, CF);

alter table PERSONA add constraint REF_PERSO_UTENT
     foreign key (IDUTENTE)
     references UTENTE(IDUTENTE);

alter table PREVENTIVO add constraint REF_PREVE_UTENT
     foreign key (IDUTENTE)
     references UTENTE(IDUTENTE);

alter table PREVENTIVO add constraint REF_PREVE_CLIEN_FK
     foreign key (IDUTENTE, IDCLIENTE)
     references CLIENTE(IDUTENTE, IDCLIENTE);

alter table REFERENTE add constraint REF_REFER_CLIEN_FK
     foreign key (IDUTENTE, IDCLIENTE)
     references CLIENTE(IDUTENTE, IDCLIENTE);

alter table TELEFONO add constraint REF_TELEF_PERSO_FK
     foreign key (IDUTENTE, IDPERSONA)
     references PERSONA(IDUTENTE, IDPERSONA);

alter table UTENTE add constraint ID_UTENTE_CHK
     check(exists(select * from DATORE_LAVORO
                  where DATORE_LAVORO.IDUTENTE = IDUTENTE)); 

alter table UTENTE add constraint COEX_UTENTE_2
     check((NOME is not null and COGNOME is not null)
           or (NOME is null and COGNOME is null)); 

alter table UTENTE add constraint COEX_UTENTE_1
     check((NOME is not null and COGNOME is not null and PROVVIGIONE_DEFAULT is not null)
           or (NOME is null and COGNOME is null and PROVVIGIONE_DEFAULT is null)); 

alter table UTENTE add constraint COEX_UTENTE
     check((RAGIONE_SOCIALE is not null and SEDE_LEGALE is not null)
           or (RAGIONE_SOCIALE is null and SEDE_LEGALE is null)); 

alter table VENDITA add constraint COEX_VENDITA
     check((TIPOAGENTE is not null and PROVVIGIONE is not null)
           or (TIPOAGENTE is null and PROVVIGIONE is null)); 

alter table VENDITA add constraint REF_VENDI_UTENT
     foreign key (IDUTENTE)
     references UTENTE(IDUTENTE);

alter table VENDITA add constraint REF_VENDI_CLIEN_FK
     foreign key (IDUTENTE, IDCLIENTE)
     references CLIENTE(IDUTENTE, IDCLIENTE);

alter table VENDITEFATTURA add constraint REF_VENDI_VENDI_FK
     foreign key (IDUTENTE, IDVENDITA)
     references VENDITA(IDUTENTE, IDVENDITA);

alter table VENDITEFATTURA add constraint REF_VENDI_FATTU
     foreign key (ANNO, NUMERO, IDUTENTE)
     references FATTURA(ANNO, NUMERO, IDUTENTE);

alter table VOCEFATTURA add constraint REF_VOCEF_FATTU_FK
     foreign key (IDUTENTE, ANNO, NUMEROFATTURA)
     references FATTURA(IDUTENTE, ANNO, NUMEROFATTURA);

alter table VOCEVENDITA add constraint REF_VOCEV_VENDI_FK
     foreign key (IDUTENTE, IDVENDITA)
     references VENDITA(IDUTENTE, IDVENDITA);

alter table VOCIPREVENTIVO add constraint REF_VOCIP_PREVE_FK
     foreign key (IDUTENTE, IDPREVENTIVO)
     references PREVENTIVO(IDUTENTE, IDPREVENTIVO);


-- Index Section
-- _____________ 

create unique index ID_APPUNTAMENTICON_IND
     on APPUNTAMENTICON (IDUTENTE, IDAPPUNTAMENTO, IDINTERMEDIARIO, IDCLIENTE, IDESTERNO);

create index REF_APPUN_INTER_IND
     on APPUNTAMENTICON (IDUTENTE, IDINTERMEDIARIO);

create index REF_APPUN_CLIEN_IND
     on APPUNTAMENTICON (IDUTENTE, IDCLIENTE);

create index REF_APPUN_ESTER_IND
     on APPUNTAMENTICON (IDUTENTE, IDESTERNO);

create unique index ID_APPUNTAMENTO_IND
     on APPUNTAMENTO (IDUTENTE, IDAPPUNTAMENTO);

create unique index ID_CLIENTE_IND
     on CLIENTE (IDUTENTE, IDCLIENTE);

create index REF_CLIEN_PERSO_IND
     on CLIENTE (IDUTENTE, IDPERSONA);

create unique index ID_DATORE_LAVORO_IND
     on DATORE_LAVORO (IDDATORELAVORO);

create index EQU_DATOR_UTENT_IND
     on DATORE_LAVORO (IDUTENTE);

create unique index ID_ESTERNO_IND
     on ESTERNO (IDUTENTE, IDESTERNO);

create unique index ID_FATTURA_IND
     on FATTURA (IDUTENTE, ANNO, NUMERO);

create index REF_FATTU_DATOR_IND
     on FATTURA (IDDATORELAVORO);

create unique index ID_INTERMEDIARIO_IND
     on INTERMEDIARIO (IDUTENTE, IDINTERMEDIARIO);

create index REF_INTER_PERSO_IND
     on INTERMEDIARIO (IDUTENTE, IDPERSONA);

create unique index ID_MAIL_IND
     on MAIL (MAIL, IDUTENTE, IDPERSONA);

create index REF_MAIL_PERSO_IND
     on MAIL (IDUTENTE, IDPERSONA);

create unique index ID_MAIL_INVIATA_IND
     on MAILINVIATA (IDUTENTE, IDMAIL);

create index REF_MAIL__PERSO_IND
     on MAILINVIATA (IDUTENTE, IDPERSONA);

create unique index SID_PERSONA_IND
     on PERSONA (IDUTENTE, CF);

create unique index ID_PERSONA_IND
     on PERSONA (IDUTENTE, IDPERSONA);

create unique index ID_PREVENTIVO_IND
     on PREVENTIVO (IDUTENTE, IDPREVENTIVO);

create index REF_PREVE_CLIEN_IND
     on PREVENTIVO (IDUTENTE, IDCLIENTE);

create unique index ID_REFERENTE_IND
     on REFERENTE (NOME, IDUTENTE, IDCLIENTE);

create index REF_REFER_CLIEN_IND
     on REFERENTE (IDUTENTE, IDCLIENTE);

create unique index ID_TELEFONO_IND
     on TELEFONO (TELEFONO, IDUTENTE, IDPERSONA);

create index REF_TELEF_PERSO_IND
     on TELEFONO (IDUTENTE, IDPERSONA);

create unique index SID_UTENTE_IND
     on UTENTE (USERNAME);

create unique index ID_UTENTE_IND
     on UTENTE (IDUTENTE);

create unique index ID_VENDITA_IND
     on VENDITA (IDUTENTE, IDVENDITA);

create index REF_VENDI_CLIEN_IND
     on VENDITA (IDUTENTE, IDCLIENTE);

create unique index ID_VENDITEFATTURA_IND
     on VENDITEFATTURA (ANNO, NUMERO, IDUTENTE, IDVENDITA);

create index REF_VENDI_VENDI_IND
     on VENDITEFATTURA (IDUTENTE, IDVENDITA);

create unique index ID_VOCEFATTURA_IND
     on VOCEFATTURA (NUMEROVOCE, IDUTENTE, ANNO, NUMEROFATTURA);

create index REF_VOCEF_FATTU_IND
     on VOCEFATTURA (IDUTENTE, ANNO, NUMEROFATTURA);

create unique index ID_VOCEVENDITA_IND
     on VOCEVENDITA (NUMERO, IDUTENTE, IDVENDITA);

create index REF_VOCEV_VENDI_IND
     on VOCEVENDITA (IDUTENTE, IDVENDITA);

create unique index ID_VOCIPREVENTIVO_IND
     on VOCIPREVENTIVO (NUMERO, IDUTENTE, IDPREVENTIVO);

create index REF_VOCIP_PREVE_IND
     on VOCIPREVENTIVO (IDUTENTE, IDPREVENTIVO);

