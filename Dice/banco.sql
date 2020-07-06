CREATE TABLE IF NOT EXISTS `mydb`.`categoria` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `categoria_nome` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`fabricante`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`fabricante` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `nome_fabricante` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`produto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`produto` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `produto_nome` VARCHAR(90) NOT NULL,
  `produto_preco` DOUBLE NOT NULL,
  `produto_informacoes` VARCHAR(455) NULL,
  `categoria_Id` INT NOT NULL,
  `fornecedor_Id` INT NOT NULL,
  PRIMARY KEY (`Id`, `categoria_Id`, `fornecedor_Id`),
  INDEX `fk_produto_categoria1_idx` (`categoria_Id` ASC) VISIBLE,
  INDEX `fk_produto_fornecedor1_idx` (`fornecedor_Id` ASC) VISIBLE,
  CONSTRAINT `fk_produto_categoria1`
    FOREIGN KEY (`categoria_Id`)
    REFERENCES `mydb`.`categoria` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_produto_fornecedor1`
    FOREIGN KEY (`fornecedor_Id`)
    REFERENCES `mydb`.`fabricante` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;