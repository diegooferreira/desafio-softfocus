-- --------------------------------------------------------

--
-- Estrutura da tabela `comunicacao_perda`
--

CREATE TABLE `comunicacao_perda` (
  `ID` int(11) NOT NULL,
  `NOME` varchar(100) NOT NULL,
  `EMAIL` varchar(30) NOT NULL,
  `CPF` varchar(11) NOT NULL,
  `LOCALIZACAO_LATITUDE` decimal(10,8) NOT NULL,
  `LOCALIZACAO_LONGITUDE` decimal(10,8) NOT NULL,
  `TIPO_LAVOURA` varchar(100) NOT NULL,
  `DATA_COLHEITA` date NOT NULL,
  `ID_EVENTO` int(11) NOT NULL COMMENT '1 - CHUVA EXCESSIVA 2 - GEADA 3 - GRANIZO 4 - SECA 5 - VENDAVAL 6 - RAIO'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Estrutura da tabela `evento`
--

CREATE TABLE `evento` (
  `ID` int(11) NOT NULL,
  `DESCRICAO` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `evento`
--

INSERT INTO `evento` (`ID`, `DESCRICAO`) VALUES
(1, 'CHUVA EXCESSIVA'),
(2, 'GEADA'),
(3, 'GRANIZO'),
(4, 'SECA'),
(5, 'VENDAVAL'),
(6, 'RAIO');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `comunicacao_perda`
--
ALTER TABLE `comunicacao_perda`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `EVENTO_CP_FK_idx` (`ID_EVENTO`);

--
-- Índices para tabela `evento`
--
ALTER TABLE `evento`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `comunicacao_perda`
--
ALTER TABLE `comunicacao_perda`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `comunicacao_perda`
--
ALTER TABLE `comunicacao_perda`
  ADD CONSTRAINT `EVENTO_CP_FK` FOREIGN KEY (`ID_EVENTO`) REFERENCES `evento` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;
