﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wencove.conexion.model.entity
{
    public class OrdenCompra
    {
        public string OC_CNUMORD { get; set; }
        public string OC_PRINCIPAL { get; set; }
        public DateTime OC_DFECDOC { get; set; }
        public string OC_LOTE { get; set; }
        public string oc_ccodpro { get; set; }
        public string OC_CRAZSOC { get; set; }
        public string OC_CDIRPRO { get; set; }
        public string OC_CCOTIZA { get; set; }
        public string OC_CCODMON { get; set; }
        public string OC_CFORPAG { get; set; }
        public string OC_NTIPCAM { get; set; }
        public DateTime OC_DFECENT { get; set; }
        public string OC_COBSERV { get; set; }
        public string OC_CSOLICT { get; set; }
        public string OC_CTIPENV { get; set; }
        public string OC_CENTREG { get; set; }
        public string OC_CSITORD { get; set; }
        public decimal OC_NIMPORT { get; set; }
        public decimal OC_NDESCUE { get; set; }
        public decimal OC_NIGV { get; set; }
        public decimal OC_NVENTA { get; set; }
        public DateTime OC_DFECACT { get; set; }
        public string OC_CHORA { get; set; }
        public string OC_CUSUARI { get; set; }
        public string OC_CFECDOC { get; set; }
        public string OC_CCONVER { get; set; }
        public string OC_CFACNOMBRE { get; set; }
        public string OC_CFACRUC { get; set; }
        public string OC_CFACDIREC { get; set; }
        public string OC_CDOCREF { get; set; }
        public string OC_CNRODOCREF { get; set; }
        public string OC_ORDFAB { get; set; }
        public string OC_SOLICITA { get; set; }
        public decimal OC_NFLETE { get; set; }
        public decimal OC_NSEGURO { get; set; }
        public string OC_CTIPOC { get; set; }
        public string OC_DESPACHO { get; set; }
        public string OC_TIPO { get; set; }
        public string EST_CODIGO { get; set; }
        public string EST_NOMBRE { get; set; }
       
        public string COVMON_CODIGO { get; set; }
        public string nameArticulo { get; set; }
        public decimal precio { get; set; }
        public decimal descuento { get; set; }

        public decimal cantidad { get; set; }
        public decimal total { get; set; }
        
        public string RUC { get; set; }


        public List<DetalleOrdenCompra> detalles;


        public OrdenCompra()
        {

            detalles = new List<DetalleOrdenCompra>();
            OC_DFECDOC = DateTime.Now;
            OC_DFECENT = DateTime.Now;
        }

    }

    public class DetalleOrdenCompra
    {
        public string OC_CNUMORD { get; set; }
        public string oc_ccodpro { get; set; }
        public DateTime OC_DFECDOC { get; set; }
        public string OC_CITEM { get; set; }
        public string oc_ccodigo { get; set; }
        public string OC_CCODREF { get; set; }
        public string OC_CDESREF { get; set; }
        public string OC_CUNIDAD { get; set; }
        public string OC_CUNIREF { get; set; }
        public decimal OC_NFACTOR { get; set; }
        public decimal OC_NPREUNI { get; set; }
        public decimal OC_NCANTID { get; set; }
        public decimal OC_NDSCPOR { get; set; }
        public decimal OC_NDESCTO { get; set; }
        public decimal OC_NIGV { get; set; }
        public decimal OC_NIGVPOR { get; set; }
        public decimal OC_NPRENET { get; set; }
        public decimal OC_NTOTVEN { get; set; }
        public decimal OC_NTOTNET { get; set; }
        public decimal OC_NCANTEN { get; set; }
        public decimal OC_NCANSAL { get; set; }
        public decimal OC_ENTREGADO { get; set; }
        public decimal OC_SALDO { get; set; }
        public string OC_COMENTA { get; set; }
        public string OC_CESTADO { get; set; }
        public string OC_FUNICOM { get; set; }
        public decimal OC_NRECIBI { get; set; }
        public string OC_CCOMEN1 { get; set; }
        public string OC_CCOMEN2 { get; set; }
        public string OC_GLOSA { get; set; }
        public decimal OC_PRECIOVEN { get; set; }
        public string CENTCOST { get; set; }

        //private string detalle; // field
        public string Codigo   // property
        {
            get { return OC_CNUMORD+"-"+ OC_CITEM; }
            
        }
    }
}