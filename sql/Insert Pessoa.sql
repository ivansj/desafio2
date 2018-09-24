use GContaDB

if(not exists (SELECT NULL FROM Pessoa))
	INSERT INTO Pessoa (cpf, dataNascimento, nome)
	VALUES ('24218064539','1987-01-01', 'Teste')