using OpenQA.Selenium.Chrome;
using System.ComponentModel;

var url = "https://web.whatsapp.com";

var contatos = new List<string>()
{
    "* Learning"
};

string applicationPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

string drivePath = applicationPath + @"\ChromeDriver\";

ChromeDriver driver = new ChromeDriver(drivePath);

driver.Navigate().GoToUrl(url);

driver.Manage().Window.Maximize();

Thread.Sleep(10000); // 10 segundos

foreach (var contato in contatos)
{
    var caixaTexto = driver.FindElement(OpenQA.Selenium.By.XPath($"//div[@title='Caixa de texto de pesquisa']"));
    if (caixaTexto is null) return;

    caixaTexto.SendKeys(contato);
Thread.Sleep(1000);

    var elementoPesquisa = driver.FindElement(OpenQA.Selenium.By.XPath($"//div[@data-testid='cell-frame-container']"));
    elementoPesquisa.Click();

    Thread.Sleep(1000);

    var chatMensagem = driver.FindElement(OpenQA.Selenium.By.XPath("//div[@title='Mensagem']"));

    chatMensagem.SendKeys("Hi bro!");

    Thread.Sleep(1000);

    var botaoEnviar = driver.FindElement(OpenQA.Selenium.By.XPath("//span[@data-testid='send']"));

    botaoEnviar.Click();
}