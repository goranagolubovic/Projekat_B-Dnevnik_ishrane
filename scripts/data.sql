INSERT INTO korisnik (idKORISNIK,Ime,Prezime,KorisnickoIme,Lozinka,Godiste,Tema)
VALUES (1,'Marko','Markovic',"marko_markovic","marko123",1997,"candy");
INSERT INTO korisnik (idKORISNIK,Ime,Prezime,KorisnickoIme,Lozinka,Godiste,Tema)
VALUES (2,'Pero','Peric',"pero*peric","pero1234",1983,"candy");
INSERT INTO korisnik (idKORISNIK,Ime,Prezime,KorisnickoIme,Lozinka,Godiste,Tema)
VALUES (3,'Mirko','Mirkovic',"mirkomirkovic","mirko**",1999,"candy");
INSERT INTO korisnik (idKORISNIK,Ime,Prezime,KorisnickoIme,Lozinka,Godiste,Tema)
VALUES (4,'Petra','Petrovic',"petrovicpetra","123petra",1991,"candy");
INSERT INTO korisnik (idKORISNIK,Ime,Prezime,KorisnickoIme,Lozinka,Godiste,Tema)
VALUES (5,'Marija','Maric',"marija_m","1234marija",1996,"candy");
INSERT INTO korisnik (idKORISNIK,Ime,Prezime,KorisnickoIme,Lozinka,Godiste,Tema)
VALUES (6,'Mia','Mijic',"miaaa","**mia**",1992,"candy");

insert into trener values (1);
insert into trener values(3);


insert into kandidat values(2,1);
insert into kandidat values(4,1);
insert into kandidat values(5,1);
insert into kandidat values(6,1);

set @datetime_var=current_timestamp();

insert into plan_ishrane
values(1,@datetime_var,"Proja sa sirom,Voće,Bijela čorba,Salata sa boranijom",3,2,"ponedjeljak");
insert into plan_ishrane
values(2,@datetime_var,"Pita sa prosom,Voće,Punjene paprike,Musli sa jogurtom",3,2,"utorak");
insert into plan_ishrane
values(3,@datetime_var,"Palačinke od banane,Voće,Sočivo sa povrćem,Integralni sutlijaš",3,2,"srijeda");
insert into plan_ishrane
values(4,@datetime_var,"Namaz od leblebije,Voće,Potaž sa tikvicama,Salata sa tunjevinom",3,2,"četvrtak");
insert into plan_ishrane
values(5,@datetime_var,"Pita od heljde,Voće,Riba,Humus i tost",3,2,"petak");
insert into plan_ishrane
values(6,@datetime_var,"Kukuruzni hljeb i riblji namaz,Voće,Varivo od piletine,Proja sa tikvicama,Kiselo mlijeko",3,2,"subota");
insert into plan_ishrane
values(7,@datetime_var,"Palačinka od heljdinog brašna,Voće,Rižoto sa piletinom,Paprike sa sirom",3,2,"nedjelja");

set @datetime_var=current_timestamp();
insert into plan_ishrane
values(8,@datetime_var,"Proteinske palačinke,Jogurt,Pileće ćufte,Ovsena kaša",1,4,"ponedjeljak");
insert into plan_ishrane
values(9,@datetime_var,"Omlet sa šampinjonima,Voće,Losos i špargle,Riblja pašteta",1,4,"utorak");
insert into plan_ishrane
values(10,@datetime_var,"Palačinke sa aronijom,Brusketi sa mocarelom,Sočivo sa povrćem,Grčka salata",1,4,"srijeda");
insert into plan_ishrane
values(11,@datetime_var,"Humus i tost,Voće,Low carb piletina,Grčka salata",1,4,"četvrtak");
insert into plan_ishrane
values(12,@datetime_var,"Muffini bez brašna,Jogurt sa sjemenkama,Riba,Ovsena kaša",1,4,"petak");
insert into plan_ishrane
values(13,@datetime_var,"Omlet sa povrćem,Voće,Varivo od piletine,Mango sutlijaš",1,4,"subota");
insert into plan_ishrane
values(14,@datetime_var,"Zeleni sendvič,Voće,Rižoto sa piletinom,Paprike sa sirom",1,4,"nedjelja");

set @datetime_var=current_timestamp();

insert into plan_vjezbanja
values(1, @datetime_var,"Gornji dio tijela,Šetanje",1,4,"ponedjeljak");
insert into plan_vjezbanja
values(2, @datetime_var,"Kardio",1,4,"utorak");
insert into plan_vjezbanja
values(3, @datetime_var,"Odmor",1,4,"srijeda");
insert into plan_vjezbanja
values(4, @datetime_var,"Donji dio tijela,Trčanje",1,4,"četvrtak");
insert into plan_vjezbanja
values(5, @datetime_var,"Odmor",1,4,"petak");
insert into plan_vjezbanja
values(6, @datetime_var,"Trčanje",1,4,"subota");
insert into plan_vjezbanja
values(7, @datetime_var,"Odmor",1,4,"nedjelja");

set @datetime_var=current_timestamp();

insert into plan_vjezbanja
values(8, @datetime_var,"Donji dio tijela,Plivanje",3,5,"ponedjeljak");
insert into plan_vjezbanja
values(9, @datetime_var,"Gornji dio tijela,Šetanje",3,5,"utorak");
insert into plan_vjezbanja
values(10, @datetime_var,"Šetanje",3,5,"srijeda");
insert into plan_vjezbanja
values(11, @datetime_var,"Odmor",3,5,"četvrtak");
insert into plan_vjezbanja
values(12, @datetime_var,"Donji dio tijela,Šetanje",3,5,"petak");
insert into plan_vjezbanja
values(13, @datetime_var,"Trčanje,Šetanje",3,5,"subota");
insert into plan_vjezbanja
values(14, @datetime_var,"Odmor",3,5,"nedjelja");


insert into namirnica(idNAMIRNICA,Naziv,KalorijskaVrijednost,Proteini,Masti,UgljikoHidrati)
values(1,'Proso',119,3.5,1,23.7);
insert into namirnica(idNAMIRNICA,Naziv,KalorijskaVrijednost,Proteini,Masti,UgljikoHidrati)
values(2,'Jaje',143,12.6,10.6,1.1);
insert into namirnica(idNAMIRNICA,Naziv,KalorijskaVrijednost,Proteini,Masti,UgljikoHidrati)
values(3,'Pileći file',197,29.8,7.8,0);
insert into namirnica(idNAMIRNICA,Naziv,KalorijskaVrijednost,Proteini,Masti,UgljikoHidrati)
values(4,'Konzervirana tuna',243,16.3,19.7,0);
insert into namirnica(idNAMIRNICA,Naziv,KalorijskaVrijednost,Proteini,Masti,UgljikoHidrati)
values(5,'Pirinač',130,2.4,0.2,28.6);
insert into namirnica(idNAMIRNICA,Naziv,KalorijskaVrijednost,Proteini,Masti,UgljikoHidrati)
values(6,'Paprika',31,1,0.3,6);

insert into mjerenje
values (1,2,current_timestamp(),78.9);
insert into mjerenje
values (1,6,current_timestamp(),62.1);


insert into obrok
values(6,2,30,"doručak",current_date());
insert into obrok
values(6,1,200,"ručak",current_date());
insert into obrok
values(6,5,120,"večera",current_date());
insert into obrok
values(6,6,150,"užina",current_date());



