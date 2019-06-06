CREATE DATABASE bd_crud;

USE bd_crud;

CREATE TABLE tb_dados
(
	cd_dados INT AUTO_INCREMENT,
    nm_nome VARCHAR(60) NOT NULL,
    sg_estado CHAR(2) NOT NULL,
    nm_cidade VARCHAR(50) NOT NULL,
    ds_endereco VARCHAR(100) NOT NULL,
	PRIMARY KEY (cd_dados)
);

SELECT * FROM tb_dados;

INSERT INTO tb_dados ( cd_dados,nm_nome,sg_estado,nm_cidade,ds_endereco) VALUES
					  (NULL, 'Rubem','MG','Belo Horizonte','lauro Gomes Vidal');
                      
DELETE FROM tb_dados WHERE cd_dados = 3;

SELECT nm_nome,sg_estado,nm_cidade,ds_endereco FROM tb_dados WHERE cd_dados = 1;