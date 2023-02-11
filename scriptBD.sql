-- -----------------------------------------------------
-- Schema proyectos_de_vivienda
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `proyectos_de_vivienda` DEFAULT CHARACTER SET utf8 ;
USE `proyectos_de_vivienda` ;

-- -----------------------------------------------------
-- Table `proyectos_de_vivienda`.`usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `proyectos_de_vivienda`.`usuario` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `primer_nombre` VARCHAR(255) NOT NULL,
  `segundo_nombre` VARCHAR(255) NULL,
  `primer_apellido` VARCHAR(255) NOT NULL,
  `segundo_apellido` VARCHAR(255) NULL,
  `numero_documento` INT NOT NULL,
  `email` VARCHAR(255) NOT NULL,
  `telefono` VARCHAR(255) NOT NULL,
  `tipo_documento` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) VISIBLE,
  UNIQUE INDEX `numero_documento_UNIQUE` (`numero_documento` ASC) VISIBLE,
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE);


insert into usuario (primer_nombre,primer_apellido,numero_documento,email,telefono,tipo_documento) 
values ("cecilia","bohorques",43251698,"ceci@gmail.com","3215648975","cedula");



-- Table `proyectos_de_vivienda`.`constructora`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `proyectos_de_vivienda`.`constructora` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nit` INT NOT NULL,
  `nombre` VARCHAR(255) NOT NULL,
  `direccion` VARCHAR(255) NOT NULL,
  `contacto` VARCHAR(255) NOT NULL,
  `email` VARCHAR(255) NOT NULL,
  `usuario_id` INT NOT NULL,
  `estado` TINYINT NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `codigo_UNIQUE` (`nit` ASC) VISIBLE,
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) VISIBLE,
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  UNIQUE INDEX `nombre_UNIQUE` (`nombre` ASC) VISIBLE,
  CONSTRAINT `usuario_id`
    FOREIGN KEY (`usuario_id`)
    REFERENCES `proyectos_de_vivienda`.`usuario` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


insert into constructora (nit,nombre,direccion,contacto,email,usuario_id,estado) 
 values (100152301,"css","diagonal","301256489","cs@gmail.com",1,1);
 
 
 -- Table `proyectos_de_vivienda`.`proyecto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `proyectos_de_vivienda`.`proyecto` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `direccion` VARCHAR(255) NOT NULL,
  `contacto` VARCHAR(255) NOT NULL,
  `nombre` VARCHAR(255) NOT NULL,
  `fecha_inicio` DATE NOT NULL,
  `fecha_entrega` DATE NOT NULL,
  `area` VARCHAR(255) NOT NULL,
  `precio` FLOAT NOT NULL,
  `estado` TINYINT NOT NULL,
  `constructora_id` INT NOT NULL,
  `tipo_proyecto` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  INDEX `constructora_id_idx` (`constructora_id` ASC) VISIBLE,
  CONSTRAINT `constructora_id`
    FOREIGN KEY (`constructora_id`)
    REFERENCES `proyectos_de_vivienda`.`constructora` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

insert into proyecto (direccion,contacto,nombre,fecha_inicio,fecha_entrega,area,precio,estado,constructora_id,tipo_proyecto) 
 values ("calle","23654802","claveles","2000-06-10","2012-03-25","55",150000000,1,1,"vis");
 
 
 -- Table `proyectos_de_vivienda`.`cliente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `proyectos_de_vivienda`.`cliente` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `numero_documento` INT NOT NULL,
  `tipo_documento` VARCHAR(255) NOT NULL,
  `nombre_cliente` VARCHAR(255) NOT NULL,
  `telefono` VARCHAR(255) NOT NULL,
  `direccion` VARCHAR(255) NOT NULL,
  `email` VARCHAR(255) NOT NULL,
  `fecha_nacimiento` DATE NOT NULL,
  `estado` TINYINT NOT NULL,
  `usuario_id` INT NOT NULL,
  `proyecto_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `codigo_de_cliente_idx` (`usuario_id` ASC) VISIBLE,
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  UNIQUE INDEX `numero_documento_UNIQUE` (`numero_documento` ASC) VISIBLE,
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) VISIBLE,
  INDEX `proyecto_id_idx` (`proyecto_id` ASC) VISIBLE)
ENGINE = InnoDB;

insert into cliente (numero_documento,tipo_documento,nombre_cliente,telefono,direccion,email,fecha_nacimiento,estado,usuario_id,proyecto_id) 
values (10023659,"cedula","Gonzalo",318520496,"calle","bjjh@gmail.com","2000-06-10",1,1,1);


-- Table `proyectos_de_vivienda`.`tipo_documento`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `proyectos_de_vivienda`.`tipo_documento` (
  `id` varchar (5) NOT NULL,
  `documento` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE);


insert into tipo_documento (id,documento) 
values ("CC","Cedula");
insert into tipo_documento (id,documento) 
values ("PP","Pasaporte");
insert into tipo_documento (id,documento) 
values ("CE","Cedula de Extranjeria");
insert into tipo_documento (id,documento) 
values ("TI","Tarjeta de Identidad");
insert into tipo_documento (id,documento) 
values ("PE","Permiso Especial");


 




















