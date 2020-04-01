using DicaDaCoruja.Negocios.Acesso;
using System;
using System.Drawing;
using System.IO;

namespace DicaDaCoruja.Interface.Register
{
    public partial class Produtos : System.Web.UI.Page
    {
        private GravarProduto _gravar;
        private LerSelect _ler;
        private GeraUpdate _update;
        private LerNumProduto _numprd;
        protected void Page_Load(object sender, EventArgs e)
        {
            Reload();
        }

        protected void Reload()
        {
            TextProduto.MaxLength = 20;
            TextDescrição.MaxLength = 200;
            _ler = new LerSelect();
            var Dt = _ler.LerProduto();
            if (Dt != null)
            {
                GridProdutos.DataSource = Dt.ValDataTable;
                GridProdutos.DataBind();
            }
            _ler = new LerSelect();
            var DtCatePai = _ler.LerDropCategoriaPai();
            if (DtCatePai != null && DropCategoriaPai.Text == "")
            {
                DropCategoriaPai.DataTextField = "Categoria";
                DropCategoriaPai.DataSource = DtCatePai.ValDataTable;
                DropCategoriaPai.DataBind();
                DropCategoriaPai.AppendDataBoundItems = true;
            }
        }

        protected void Change_CategoriaPai(Object sender, EventArgs e)
        {
            DropCategoriaFilho.Items.Clear();
            _ler = new LerSelect();
            var DtCateFilho = _ler.LerDropCategoriaFilho(DropCategoriaPai.SelectedItem.Value);
            if (DtCateFilho != null)
            {
                DropCategoriaFilho.DataTextField = "Categoria Des";
                DropCategoriaFilho.DataValueField = "Categoria Val";
                DropCategoriaFilho.DataSource = DtCateFilho.ValDataTable;
                DropCategoriaFilho.DataBind();
                DropCategoriaFilho.AppendDataBoundItems = true;
            }
        }

        protected void BtnInserir_Click(object sender, EventArgs e)
        {
            if (DropCategoriaPai.SelectedValue.ToString() != "Categorias" && DropCategoriaFilho.SelectedValue.ToString() != "Categorias" && TextProduto.Text != "" && TextDescrição.Text != "" && UpldFoto.PostedFile.ToString() != "")
            {
                _numprd = new LerNumProduto();
                var NumeroProduto = _numprd.LerNumeroPrd();
                if (NumeroProduto.ValMenssage != null)
                {
                    LabelStatus.Text = "";
                    _gravar = new GravarProduto();
                    if (UpldFoto.PostedFile.ContentLength < 2097152)
                    {
                        try
                        {
                            if (UpldFoto.HasFile)
                            {
                                try
                                {
                                    if (UpldFoto.PostedFile.ContentType == "image/jpeg")
                                    {
                                        try
                                        {
                                            UpldFoto.PostedFile.SaveAs(Server.MapPath("~/Uploaded/" + NumeroProduto.ValMenssage.Trim() + ".jpg"));
                                            var Gravar = _gravar.InserirProduto(DropCategoriaFilho.SelectedValue.ToString(), TextProduto.Text, TextDescrição.Text, "../Uploaded/" + NumeroProduto.ValMenssage.Trim() + ".jpg");
                                            /*
                                            string imagePath = "~/Uploaded/" + NumeroProduto.ValMenssage.Trim() + ".jpg";
                                            System.Drawing.Image fullSizeImg = System.Drawing.Image.FromFile(imagePath);
                                            var thumbnailImg = new Bitmap(400, 400);
                                            var thumbGraph = Graphics.FromImage(thumbnailImg);
                                            thumbGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                                            thumbGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                                            thumbGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
                                            var imageRectangle = new Rectangle(0, 0, 400, 400);
                                            thumbGraph.DrawImage(fullSizeImg, imageRectangle);
                                            string targetPath = imagePath.Replace(NumeroProduto.ValMenssage.Trim(), NumeroProduto.ValMenssage.Trim() + ".jpg");
                                            thumbnailImg.Save(targetPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                                            thumbnailImg.Dispose();
                                            */
                                            LabelStatus.Text = Gravar.ValMenssage.ToString();
                                            //targetPath;
                                        }
                                        catch (Exception)
                                        {

                                        }
                                    }
                                    else
                                    {
                                        LabelStatus.Text = "É permitido carregar apenas imagens jpeg!";
                                    }
                                }
                                catch (Exception)
                                {
                                    LabelStatus.Text = "O arquivo não pôde ser carregado.";
                                }
                            }
                        }
                        catch (Exception)
                        {
                            LabelStatus.Text = "O arquivo não pôde ser carregado.";
                        }
                    }
                    else
                    {
                        LabelStatus.Text = "Não é permitido carregar mais do que 2 MB";
                    }
                }
                if (LabelStatus.Text == "Registro inserido com sucesso")
                {
                    LabelStatus.CssClass = "TxtVerde";
                    TextProduto.Text = "";
                    TextDescrição.Text = "";
                }
                else
                {
                    LabelStatus.CssClass = "TxtVermelho";
                }
                Reload();
            }
            else
            {
                LabelStatus.Text = "É necessário preencher todos os campos";
                LabelStatus.CssClass = "TxtVermelho";
            }
        }

        protected void BtnAtivar_Click(object sender, EventArgs e)
        {
            if (TextID.Text != "")
            {
                _update = new GeraUpdate();
                var Update = _update.GerarUpdate("PRODUTOS", TextID.Text, "SPRD", "'A'");
                LabelStatus.Text = Update.ValMenssage.ToString();
                if (LabelStatus.Text == "Registro atualizado com sucesso")
                {
                    LabelStatus.CssClass = "TxtVerde";
                }
                else
                {
                    LabelStatus.CssClass = "TxtVermelho";
                }
                Reload();
            }
            else
            {
                LabelStatus.Text = "É necessário preencher ID";
                LabelStatus.CssClass = "TxtVermelho";
            }
        }

        protected void BtnInativar_Click(object sender, EventArgs e)
        {
            if (TextID.Text != "")
            {
                _update = new GeraUpdate();
                var Update = _update.GerarUpdate("PRODUTOS", TextID.Text, "SPRD", "'I'");
                LabelStatus.Text = Update.ValMenssage.ToString();
                if (LabelStatus.Text == "Registro atualizado com sucesso")
                {
                    LabelStatus.CssClass = "TxtVerde";
                }
                else
                {
                    LabelStatus.CssClass = "TxtVermelho";
                }
                Reload();
            }
            else
            {
                LabelStatus.Text = "É necessário preencher ID";
                LabelStatus.CssClass = "TxtVermelho";
            }
        }
    }
}