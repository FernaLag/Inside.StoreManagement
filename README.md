# **Inside.StoreManagement**

Uma API robusta para gerenciar pedidos de uma loja, utilizando **.NET e SQL Server Express** e padrões de design modernos.

---

### Referências

- [**Technical Design**](https://hissing-viscount-cf2.notion.site/Inside-StoreManagement-Technical-Design-17c322dfed9a8093a980d507337e64fd?pvs=74)
- [**Vídeo Demonstrativo**](https://youtu.be/-9r4k5613zU)

---

## **Configuração**

1. Instale o **Visual Studio**.
2. [Clone](https://docs.github.com/pt/repositories/creating-and-managing-repositories/cloning-a-repository) o repositório.
3. Abra o arquivo `appsettings.json`, localizado no projeto **Inside.StoreManagement.API**.

---

### **Configure o `appsettings.json` com sua conexão ao banco de dados.**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=StoreManagementDb;Trusted_Connection=True;"
  }
}
```

### Configurar o SQL Server Express

1. Certifique-se de que o **SQL Server Express** está instalado.
2. Configure o nome do servidor no formato `localhost\SQLEXPRESS`.

---

### **Execute o projeto**

```bash
dotnet run --project Inside.StoreManagement.API
```

---

### **Acesse o Swagger**

- **`https://localhost:7090/`**

---

## **Testes**

1. Navegue até o **Test Explorer** no Visual Studio.
2. Execute todos os testes.

**Destaques dos Testes**

- **Testes de Integração**: Validam a comunicação e a lógica do banco de dados.
- **Testes Unitários**: Garantem o funcionamento da lógica de negócios.

---

## **Melhorias Futuras**

- Criar um pipeline de CI/CD para deploy automatizado.
- Melhorar a documentação do Swagger.
- Adicionar componente de logging.
- Ampliar cobertura de testes.

---

## **Sobre o Autor**

Desenvolvido por [Ferna](https://github.com/FernaLag) - engenheiro de software apaixonado por soluções em .NET, integração de sistemas e arquitetura limpa.
