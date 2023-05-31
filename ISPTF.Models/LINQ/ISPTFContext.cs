using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ISPTF.Models
{
    public partial class ISPTFContext : DbContext
    {
        public ISPTFContext()
        {
        }

        public ISPTFContext(DbContextOptions<ISPTFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<BOT_Classification> BOT_Classifications { get; set; }
        public virtual DbSet<BOT_ISIC> BOT_ISICs { get; set; }
        public virtual DbSet<CustRelateISP> CustRelateISPs { get; set; }
        public virtual DbSet<IBAFTX180105> IBAFTX180105s { get; set; }
        public virtual DbSet<IBBFTX180105> IBBFTX180105s { get; set; }
        public virtual DbSet<IBBFTX1801052> IBBFTX1801052s { get; set; }
        public virtual DbSet<IBCFTX180105> IBCFTX180105s { get; set; }
        public virtual DbSet<IdentityRole> IdentityRoles { get; set; }
        public virtual DbSet<IdentityUser> IdentityUsers { get; set; }
        public virtual DbSet<IdentityUserClaim> IdentityUserClaims { get; set; }
        public virtual DbSet<IdentityUserLogin> IdentityUserLogins { get; set; }
        public virtual DbSet<IdentityUserProfile> IdentityUserProfiles { get; set; }
        public virtual DbSet<IdentityUserRole> IdentityUserRoles { get; set; }
        public virtual DbSet<Load_LimitColl> Load_LimitColls { get; set; }
        public virtual DbSet<SCL> SCLs { get; set; }
        public virtual DbSet<SCV> SCVs { get; set; }
        public virtual DbSet<Sheet12_> Sheet12_s { get; set; }
        public virtual DbSet<Sheet1_> Sheet1_s { get; set; }
        public virtual DbSet<Sheet22_> Sheet22_s { get; set; }
        public virtual DbSet<TMP_OSCC> TMP_OSCCs { get; set; }
        public virtual DbSet<TMP_REPOSGRPCL> TMP_REPOSGRPCLs { get; set; }
        public virtual DbSet<TMP_SUMACC> TMP_SUMACCs { get; set; }
        public virtual DbSet<TMP_ViewVolumeCom> TMP_ViewVolumeComs { get; set; }
        public virtual DbSet<TMP_VolCorrBank> TMP_VolCorrBanks { get; set; }
        public virtual DbSet<TMP_VolCorrIncome> TMP_VolCorrIncomes { get; set; }
        public virtual DbSet<TmpATSFile> TmpATSFiles { get; set; }
        public virtual DbSet<TmpCCSMaster> TmpCCSMasters { get; set; }
        public virtual DbSet<TmpCCSOut> TmpCCSOuts { get; set; }
        public virtual DbSet<TmpCustLSum> TmpCustLSums { get; set; }
        public virtual DbSet<TmpCustLiab> TmpCustLiabs { get; set; }
        public virtual DbSet<TmpDMSPTX> TmpDMSPTXes { get; set; }
        public virtual DbSet<TmpExchange> TmpExchanges { get; set; }
        public virtual DbSet<TmpFirstDate> TmpFirstDates { get; set; }
        public virtual DbSet<TmpInvoice> TmpInvoices { get; set; }
        public virtual DbSet<TmpMasterGL> TmpMasterGLs { get; set; }
        public virtual DbSet<TmpMonAccrued> TmpMonAccrueds { get; set; }
        public virtual DbSet<TmpMonthInt> TmpMonthInts { get; set; }
        public virtual DbSet<TmpONL_LCOut> TmpONL_LCOuts { get; set; }
        public virtual DbSet<TmpONL_LCSWFile> TmpONL_LCSWFiles { get; set; }
        public virtual DbSet<TmpReveMaster> TmpReveMasters { get; set; }
        public virtual DbSet<TmpReveOut> TmpReveOuts { get; set; }
        public virtual DbSet<TmpRptMail> TmpRptMails { get; set; }
        public virtual DbSet<TmpSWIFTIN> TmpSWIFTINs { get; set; }
        public virtual DbSet<Tmp_pDailyGL> Tmp_pDailyGLs { get; set; }
        public virtual DbSet<Tmp_pMasterDailyOut> Tmp_pMasterDailyOuts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<VAuthModule> VAuthModules { get; set; }
        public virtual DbSet<VIEWDCSinterface> VIEWDCSinterfaces { get; set; }
        public virtual DbSet<VIEWMASTERPENDING> VIEWMASTERPENDINGs { get; set; }
        public virtual DbSet<VIEWTMP14GrpOSCL> VIEWTMP14GrpOSCLs { get; set; }
        public virtual DbSet<VIEWTMP24GrpOSCL> VIEWTMP24GrpOSCLs { get; set; }
        public virtual DbSet<VIEWTMP34GrpOSCL> VIEWTMP34GrpOSCLs { get; set; }
        public virtual DbSet<VIEWTMP44GrpOSCL> VIEWTMP44GrpOSCLs { get; set; }
        public virtual DbSet<VIEWTMPGrpOSCL> VIEWTMPGrpOSCLs { get; set; }
        public virtual DbSet<VIEWTMPGrpOSCL1> VIEWTMPGrpOSCL1s { get; set; }
        public virtual DbSet<VIEW_LC_INFO> VIEW_LC_INFOs { get; set; }
        public virtual DbSet<VIEW_OSbyCC> VIEW_OSbyCCs { get; set; }
        public virtual DbSet<VIEW_OSbyCCS1> VIEW_OSbyCCS1s { get; set; }
        public virtual DbSet<VIEW_REPOSGrpCL> VIEW_REPOSGrpCLs { get; set; }
        public virtual DbSet<ViewARemExchRate> ViewARemExchRates { get; set; }
        public virtual DbSet<ViewAllRemRate> ViewAllRemRates { get; set; }
        public virtual DbSet<ViewAllRemit> ViewAllRemits { get; set; }
        public virtual DbSet<ViewBankLimit> ViewBankLimits { get; set; }
        public virtual DbSet<ViewCC> ViewCCs { get; set; }
        public virtual DbSet<ViewCLBOut> ViewCLBOuts { get; set; }
        public virtual DbSet<ViewCreditLimit> ViewCreditLimits { get; set; }
        public virtual DbSet<ViewCreditLimitTmp> ViewCreditLimitTmps { get; set; }
        public virtual DbSet<ViewCustLiab> ViewCustLiabs { get; set; }
        public virtual DbSet<ViewCustLimit> ViewCustLimits { get; set; }
        public virtual DbSet<ViewCustShare> ViewCustShares { get; set; }
        public virtual DbSet<ViewDayRemExchRate> ViewDayRemExchRates { get; set; }
        public virtual DbSet<ViewDayTran> ViewDayTrans { get; set; }
        public virtual DbSet<ViewExPayment> ViewExPayments { get; set; }
        public virtual DbSet<ViewFCDout> ViewFCDouts { get; set; }
        public virtual DbSet<ViewFCPImport> ViewFCPImports { get; set; }
        public virtual DbSet<ViewFcdAccount> ViewFcdAccounts { get; set; }
        public virtual DbSet<ViewGENDLC> ViewGENDLCs { get; set; }
        public virtual DbSet<ViewGenACC> ViewGenACCs { get; set; }
        public virtual DbSet<ViewGroupGL> ViewGroupGLs { get; set; }
        public virtual DbSet<ViewLastExchRate> ViewLastExchRates { get; set; }
        public virtual DbSet<ViewMapAccount> ViewMapAccounts { get; set; }
        public virtual DbSet<ViewMapDailyGL> ViewMapDailyGLs { get; set; }
        public virtual DbSet<ViewMaster> ViewMasters { get; set; }
        public virtual DbSet<ViewMasterClose> ViewMasterCloses { get; set; }
        public virtual DbSet<ViewMasterDailyOut> ViewMasterDailyOuts { get; set; }
        public virtual DbSet<ViewMasterGL> ViewMasterGLs { get; set; }
        public virtual DbSet<ViewMasterRecalLiab> ViewMasterRecalLiabs { get; set; }
        public virtual DbSet<ViewMonInterest> ViewMonInterests { get; set; }
        public virtual DbSet<ViewNostro> ViewNostros { get; set; }
        public virtual DbSet<ViewODU> ViewODUs { get; set; }
        public virtual DbSet<ViewPayInterest> ViewPayInterests { get; set; }
        public virtual DbSet<ViewPayment> ViewPayments { get; set; }
        public virtual DbSet<ViewPending> ViewPendings { get; set; }
        public virtual DbSet<ViewQuoteRate> ViewQuoteRates { get; set; }
        public virtual DbSet<ViewRemTran> ViewRemTrans { get; set; }
        public virtual DbSet<ViewSubOutCust> ViewSubOutCusts { get; set; }
        public virtual DbSet<ViewSumMonInt> ViewSumMonInts { get; set; }
        public virtual DbSet<ViewTRnostro> ViewTRnostros { get; set; }
        public virtual DbSet<ViewTmpBack> ViewTmpBacks { get; set; }
        public virtual DbSet<ViewTransCLB> ViewTransCLBs { get; set; }
        public virtual DbSet<ViewVolumeCom> ViewVolumeComs { get; set; }
        public virtual DbSet<convEXBC> convEXBCs { get; set; }
        public virtual DbSet<convEXLC> convEXLCs { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<fm314wc03> fm314wc03s { get; set; }
        public virtual DbSet<fm315wl01> fm315wl01s { get; set; }
        public virtual DbSet<holiday> holidays { get; set; }
        public virtual DbSet<mAOCode> mAOCodes { get; set; }
        public virtual DbSet<mAPPError> mAPPErrors { get; set; }
        public virtual DbSet<mAccount> mAccounts { get; set; }
        public virtual DbSet<mAccount1> mAccount1s { get; set; }
        public virtual DbSet<mAuth> mAuths { get; set; }
        public virtual DbSet<mBankFile> mBankFiles { get; set; }
        public virtual DbSet<mBranch> mBranches { get; set; }
        public virtual DbSet<mBuArea> mBuAreas { get; set; }
        public virtual DbSet<mBusType> mBusTypes { get; set; }
        public virtual DbSet<mCampaign> mCampaigns { get; set; }
        public virtual DbSet<mControl> mControls { get; set; }
        public virtual DbSet<mControlBatch> mControlBatches { get; set; }
        public virtual DbSet<mControlDate> mControlDates { get; set; }
        public virtual DbSet<mCountry> mCountries { get; set; }
        public virtual DbSet<mCurrency> mCurrencies { get; set; }
        public virtual DbSet<mCustRate> mCustRates { get; set; }
        public virtual DbSet<mCustTFL> mCustTFLs { get; set; }
        public virtual DbSet<mCustType> mCustTypes { get; set; }
        public virtual DbSet<mCustomer> mCustomers { get; set; }
        public virtual DbSet<mDSPError> mDSPErrors { get; set; }
        public virtual DbSet<mFcdAccount> mFcdAccounts { get; set; }
        public virtual DbSet<mFcdRate> mFcdRates { get; set; }
        public virtual DbSet<mGood> mGoods { get; set; }
        public virtual DbSet<mInRateCode> mInRateCodes { get; set; }
        public virtual DbSet<mLimitCode> mLimitCodes { get; set; }
        public virtual DbSet<mLoCode> mLoCodes { get; set; }
        public virtual DbSet<mMap1PCIF> mMap1PCIFs { get; set; }
        public virtual DbSet<mMap1PLimit> mMap1PLimits { get; set; }
        public virtual DbSet<mMapAOBR> mMapAOBRs { get; set; }
        public virtual DbSet<mMapAccount> mMapAccounts { get; set; }
        public virtual DbSet<mMapBalanceCD> mMapBalanceCDs { get; set; }
        public virtual DbSet<mMapFacNo> mMapFacNos { get; set; }
        public virtual DbSet<mMapProduct> mMapProducts { get; set; }
        public virtual DbSet<mMapProductGFM> mMapProductGFMs { get; set; }
        public virtual DbSet<mMapSWIFT> mMapSWIFTs { get; set; }
        public virtual DbSet<mMapSaleUnit> mMapSaleUnits { get; set; }
        public virtual DbSet<mNostroGL> mNostroGLs { get; set; }
        public virtual DbSet<mPlanComm> mPlanComms { get; set; }
        public virtual DbSet<mProvince> mProvinces { get; set; }
        public virtual DbSet<mPurpose> mPurposes { get; set; }
        public virtual DbSet<mRelation> mRelations { get; set; }
        public virtual DbSet<mRunning> mRunnings { get; set; }
        public virtual DbSet<mSetGenGL> mSetGenGLs { get; set; }
        public virtual DbSet<mSetGenGL2> mSetGenGL2s { get; set; }
        public virtual DbSet<mSetGenGL3> mSetGenGL3s { get; set; }
        public virtual DbSet<mSetGenGLbk> mSetGenGLbks { get; set; }
        public virtual DbSet<mSetRate> mSetRates { get; set; }
        public virtual DbSet<mTextFile> mTextFiles { get; set; }
        public virtual DbSet<mTitle> mTitles { get; set; }
        public virtual DbSet<mTranType> mTranTypes { get; set; }
        public virtual DbSet<mUser> mUsers { get; set; }
        public virtual DbSet<mlogin> mlogins { get; set; }
        public virtual DbSet<pBLogLimit> pBLogLimits { get; set; }
        public virtual DbSet<pBLogLmProduct> pBLogLmProducts { get; set; }
        public virtual DbSet<pBankLSum> pBankLSums { get; set; }
        public virtual DbSet<pBankLiab> pBankLiabs { get; set; }
        public virtual DbSet<pBankLimit> pBankLimits { get; set; }
        public virtual DbSet<pBankLmProduct> pBankLmProducts { get; set; }
        public virtual DbSet<pCLogLimit> pCLogLimits { get; set; }
        public virtual DbSet<pCLogLmCC> pCLogLmCCs { get; set; }
        public virtual DbSet<pCLogLmProduct> pCLogLmProducts { get; set; }
        public virtual DbSet<pCLogShare> pCLogShares { get; set; }
        public virtual DbSet<pControlPack> pControlPacks { get; set; }
        public virtual DbSet<pCustAppv> pCustAppvs { get; set; }
        public virtual DbSet<pCustAppvDet> pCustAppvDets { get; set; }
        public virtual DbSet<pCustLSum> pCustLSums { get; set; }
        public virtual DbSet<pCustLiab> pCustLiabs { get; set; }
        public virtual DbSet<pCustLimit> pCustLimits { get; set; }
        public virtual DbSet<pCustLmCC> pCustLmCCs { get; set; }
        public virtual DbSet<pCustLmProduct> pCustLmProducts { get; set; }
        public virtual DbSet<pCustShare> pCustShares { get; set; }
        public virtual DbSet<pDMSFLA> pDMSFLAs { get; set; }
        public virtual DbSet<pDMSFTU> pDMSFTUs { get; set; }
        public virtual DbSet<pDMSFTX> pDMSFTXes { get; set; }
        public virtual DbSet<pDMSFTXLimit> pDMSFTXLimits { get; set; }
        public virtual DbSet<pDMSLTX> pDMSLTXes { get; set; }
        public virtual DbSet<pDMSPTX> pDMSPTXes { get; set; }
        public virtual DbSet<pDOMBE> pDOMBEs { get; set; }
        public virtual DbSet<pDOMLC> pDOMLCs { get; set; }
        public virtual DbSet<pDailyGL> pDailyGLs { get; set; }
        public virtual DbSet<pDailyGL4> pDailyGL4s { get; set; }
        public virtual DbSet<pDailyGLMap> pDailyGLMaps { get; set; }
        public virtual DbSet<pDailyGLSum> pDailyGLSums { get; set; }
        public virtual DbSet<pDailySap> pDailySaps { get; set; }
        public virtual DbSet<pDailySapHead> pDailySapHeads { get; set; }
        public virtual DbSet<pDailySapMap> pDailySapMaps { get; set; }
        public virtual DbSet<pDetailForex> pDetailForices { get; set; }
        public virtual DbSet<pDocRegInv> pDocRegInvs { get; set; }
        public virtual DbSet<pDocRegInv1> pDocRegInv1s { get; set; }
        public virtual DbSet<pDocRegInv2> pDocRegInv2s { get; set; }
        public virtual DbSet<pDocRegister> pDocRegisters { get; set; }
        public virtual DbSet<pEXInterest> pEXInterests { get; set; }
        public virtual DbSet<pExPastDue> pExPastDues { get; set; }
        public virtual DbSet<pExPayment> pExPayments { get; set; }
        public virtual DbSet<pExad> pExads { get; set; }
        public virtual DbSet<pExadSWIn> pExadSWIns { get; set; }
        public virtual DbSet<pExbc> pExbcs { get; set; }
        public virtual DbSet<pExchange> pExchanges { get; set; }
        public virtual DbSet<pExdoc> pExdocs { get; set; }
        public virtual DbSet<pExlc> pExlcs { get; set; }
        public virtual DbSet<pExpc> pExpcs { get; set; }
        public virtual DbSet<pExpc2> pExpc2s { get; set; }
        public virtual DbSet<pExpc3> pExpc3s { get; set; }
        public virtual DbSet<pExpcA> pExpcAs { get; set; }
        public virtual DbSet<pExpcOrder> pExpcOrders { get; set; }
        public virtual DbSet<pFCDText> pFCDTexts { get; set; }
        public virtual DbSet<pFcdAccTran> pFcdAccTrans { get; set; }
        public virtual DbSet<pFcdDayBalance> pFcdDayBalances { get; set; }
        public virtual DbSet<pFcdIntRate> pFcdIntRates { get; set; }
        public virtual DbSet<pHeaderForex> pHeaderForices { get; set; }
        public virtual DbSet<pHoliday> pHolidays { get; set; }
        public virtual DbSet<pIMBC> pIMBCs { get; set; }
        public virtual DbSet<pIMBL> pIMBLs { get; set; }
        public virtual DbSet<pIMBLDoc> pIMBLDocs { get; set; }
        public virtual DbSet<pIMBLText> pIMBLTexts { get; set; }
        public virtual DbSet<pIMBackPay> pIMBackPays { get; set; }
        public virtual DbSet<pIMInstall> pIMInstalls { get; set; }
        public virtual DbSet<pIMInterest> pIMInterests { get; set; }
        public virtual DbSet<pIMLC> pIMLCs { get; set; }
        public virtual DbSet<pIMLCAmend> pIMLCAmends { get; set; }
        public virtual DbSet<pIMLCCond> pIMLCConds { get; set; }
        public virtual DbSet<pIMLCDoc> pIMLCDocs { get; set; }
        public virtual DbSet<pIMLCGood> pIMLCGoods { get; set; }
        public virtual DbSet<pIMLCText> pIMLCTexts { get; set; }
        public virtual DbSet<pIMMiscTran> pIMMiscTrans { get; set; }
        public virtual DbSet<pIMMiscTranx> pIMMiscTranxes { get; set; }
        public virtual DbSet<pIMPastDue> pIMPastDues { get; set; }
        public virtual DbSet<pIMPayment> pIMPayments { get; set; }
        public virtual DbSet<pIMSG> pIMSGs { get; set; }
        public virtual DbSet<pIMTR> pIMTRs { get; set; }
        public virtual DbSet<pIMTR2> pIMTR2s { get; set; }
        public virtual DbSet<pIMTR3> pIMTR3s { get; set; }
        public virtual DbSet<pIMTRInvoice> pIMTRInvoices { get; set; }
        public virtual DbSet<pIMTRText> pIMTRTexts { get; set; }
        public virtual DbSet<pInstall> pInstalls { get; set; }
        public virtual DbSet<pIntRate> pIntRates { get; set; }
        public virtual DbSet<pLogBatch> pLogBatches { get; set; }
        public virtual DbSet<pLogFcdAccount> pLogFcdAccounts { get; set; }
        public virtual DbSet<pLogLoadText> pLogLoadTexts { get; set; }
        public virtual DbSet<pLogUser> pLogUsers { get; set; }
        public virtual DbSet<pLog_Connect1P> pLog_Connect1Ps { get; set; }
        public virtual DbSet<pLog_CustLiab> pLog_CustLiabs { get; set; }
        public virtual DbSet<pLog_ErrorConnect1P> pLog_ErrorConnect1Ps { get; set; }
        public virtual DbSet<pLog_ImportCB> pLog_ImportCBs { get; set; }
        public virtual DbSet<pLog_MainConnect1P> pLog_MainConnect1Ps { get; set; }
        public virtual DbSet<pLog_MasterOut> pLog_MasterOuts { get; set; }
        public virtual DbSet<pLog_QueryAC1P> pLog_QueryAC1Ps { get; set; }
        public virtual DbSet<pLog_Request1P> pLog_Request1Ps { get; set; }
        public virtual DbSet<pLog_SendMail> pLog_SendMails { get; set; }
        public virtual DbSet<pLog_SendMail1> pLog_SendMail1s { get; set; }
        public virtual DbSet<pLog_Swift> pLog_Swifts { get; set; }
        public virtual DbSet<pLog_SwiftInDetail> pLog_SwiftInDetails { get; set; }
        public virtual DbSet<pLog_SwiftInFile> pLog_SwiftInFiles { get; set; }
        public virtual DbSet<pLog_SwiftInHead> pLog_SwiftInHeads { get; set; }
        public virtual DbSet<pLog_SwiftR> pLog_SwiftRs { get; set; }
        public virtual DbSet<pLog_UnlockDoc> pLog_UnlockDocs { get; set; }
        public virtual DbSet<pMISCTran> pMISCTrans { get; set; }
        public virtual DbSet<pMasterDailyOut> pMasterDailyOuts { get; set; }
        public virtual DbSet<pMasterDailyOuts1> pMasterDailyOuts1s { get; set; }
        public virtual DbSet<pMasterDailyOuts2> pMasterDailyOuts2s { get; set; }
        public virtual DbSet<pMidRate> pMidRates { get; set; }
        public virtual DbSet<pMonAccrued> pMonAccrueds { get; set; }
        public virtual DbSet<pMonCustInvoice> pMonCustInvoices { get; set; }
        public virtual DbSet<pMonthlyInterest> pMonthlyInterests { get; set; }
        public virtual DbSet<pONLUnMatchCust> pONLUnMatchCusts { get; set; }
        public virtual DbSet<pPayDetail> pPayDetails { get; set; }
        public virtual DbSet<pPayment> pPayments { get; set; }
        public virtual DbSet<pReferenceNo> pReferenceNos { get; set; }
        public virtual DbSet<pRefinance> pRefinances { get; set; }
        public virtual DbSet<pRemCleanBill> pRemCleanBills { get; set; }
        public virtual DbSet<pRemCleanBillCCY> pRemCleanBillCCies { get; set; }
        public virtual DbSet<pRemPartial> pRemPartials { get; set; }
        public virtual DbSet<pRemSWMap> pRemSWMaps { get; set; }
        public virtual DbSet<pRemit> pRemits { get; set; }
        public virtual DbSet<pRemitBill> pRemitBills { get; set; }
        public virtual DbSet<pRemittance> pRemittances { get; set; }
        public virtual DbSet<pRevalueRate> pRevalueRates { get; set; }
        public virtual DbSet<pSBLC> pSBLCs { get; set; }
        public virtual DbSet<pSUMDMSPTX> pSUMDMSPTXes { get; set; }
        public virtual DbSet<pSW700> pSW700s { get; set; }
        public virtual DbSet<pSW700A> pSW700As { get; set; }
        public virtual DbSet<pSW707> pSW707s { get; set; }
        public virtual DbSet<pSWExport> pSWExports { get; set; }
        public virtual DbSet<pSWIMBC> pSWIMBCs { get; set; }
        public virtual DbSet<pSWIMBL> pSWIMBLs { get; set; }
        public virtual DbSet<pSWIMLC> pSWIMLCs { get; set; }
        public virtual DbSet<pSWIMTR> pSWIMTRs { get; set; }
        public virtual DbSet<pSWImpSBLC> pSWImpSBLCs { get; set; }
        public virtual DbSet<pSWImpText> pSWImpTexts { get; set; }
        public virtual DbSet<pSWImport> pSWImports { get; set; }
        public virtual DbSet<pSWMisc> pSWMiscs { get; set; }
        public virtual DbSet<pSWPrint> pSWPrints { get; set; }
        public virtual DbSet<pSWPrintFM> pSWPrintFMs { get; set; }
        public virtual DbSet<pSWSending> pSWSendings { get; set; }
        public virtual DbSet<pSWTextLoad> pSWTextLoads { get; set; }
        public virtual DbSet<pSendLCMail> pSendLCMails { get; set; }
        public virtual DbSet<pSumDMSFLA> pSumDMSFLAs { get; set; }
        public virtual DbSet<pSumDMSFTU> pSumDMSFTUs { get; set; }
        public virtual DbSet<pSumDMSFTX> pSumDMSFTXes { get; set; }
        public virtual DbSet<pSumDMSLTX> pSumDMSLTXes { get; set; }
        public virtual DbSet<pTradeApp> pTradeApps { get; set; }
        public virtual DbSet<pTranFcdBalance> pTranFcdBalances { get; set; }
        public virtual DbSet<pTransfer> pTransfers { get; set; }
        public virtual DbSet<pexbc2> pexbc2s { get; set; }
        public virtual DbSet<pexlc1> pexlc1s { get; set; }
        public virtual DbSet<pexlc2> pexlc2s { get; set; }
        public virtual DbSet<tUnUseAcc> tUnUseAccs { get; set; }
        public virtual DbSet<tmp_BankLiab> tmp_BankLiabs { get; set; }
        public virtual DbSet<tmp_BankLiabCust> tmp_BankLiabCusts { get; set; }
        public virtual DbSet<tmp_Comm> tmp_Comms { get; set; }
        public virtual DbSet<tmp_ExpDM> tmp_ExpDMs { get; set; }
        public virtual DbSet<tmp_ForwardCont> tmp_ForwardConts { get; set; }
        public virtual DbSet<tmp_Liability> tmp_Liabilities { get; set; }
        public virtual DbSet<tmp_LogIMCB> tmp_LogIMCBs { get; set; }
        public virtual DbSet<tmp_MainConnect1P> tmp_MainConnect1Ps { get; set; }
        public virtual DbSet<tmp_SWBankFile> tmp_SWBankFiles { get; set; }
        public virtual DbSet<tmp_Security> tmp_Securities { get; set; }
        public virtual DbSet<tmp_SwiftInDetail> tmp_SwiftInDetails { get; set; }
        public virtual DbSet<tmp_User> tmp_Users { get; set; }
        public virtual DbSet<tmp_interest> tmp_interests { get; set; }
        public virtual DbSet<tmp_rptAmortize> tmp_rptAmortizes { get; set; }
        public virtual DbSet<vBankSumFac> vBankSumFacs { get; set; }
        public virtual DbSet<vCommision> vCommisions { get; set; }
        public virtual DbSet<vContingent> vContingents { get; set; }
        public virtual DbSet<vCustLiability> vCustLiabilities { get; set; }
        public virtual DbSet<vCustSumFac> vCustSumFacs { get; set; }
        public virtual DbSet<vCustomerAcc> vCustomerAccs { get; set; }
        public virtual DbSet<vExpDMSFTXFTU> vExpDMSFTXFTUs { get; set; }
        public virtual DbSet<vForwardCont> vForwardConts { get; set; }
        public virtual DbSet<vIMFWCONT> vIMFWCONTs { get; set; }
        public virtual DbSet<vMasterMonInt> vMasterMonInts { get; set; }
        public virtual DbSet<vMasterOduLoan> vMasterOduLoans { get; set; }
        public virtual DbSet<vMonAccured> vMonAccureds { get; set; }
        public virtual DbSet<vMonthAmort> vMonthAmorts { get; set; }
        public virtual DbSet<vMonthAmortback> vMonthAmortbacks { get; set; }
        public virtual DbSet<vRefundTax> vRefundTaxes { get; set; }
        public virtual DbSet<viewBankLSum> viewBankLSums { get; set; }
        public virtual DbSet<viewBankLiab> viewBankLiabs { get; set; }
        public virtual DbSet<viewCustLSum> viewCustLSums { get; set; }
        public virtual DbSet<viewMasterLoan> viewMasterLoans { get; set; }
        public virtual DbSet<viewMasterODU> viewMasterODUs { get; set; }
        public virtual DbSet<viewOutISP> viewOutISPs { get; set; }
        public virtual DbSet<vtempCC> vtempCCs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=203.154.158.182;Database=ISPTF;User Id=sa;Password=ispadmin;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Thai_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.ApplicationUserId)
                    .HasName("PK__Account__9CBCE319A4D12698");

                entity.ToTable("Account");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedUsername)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("ApplicationUser");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedEmail)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedUsername)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BOT_Classification>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BOT_Classification");

                entity.Property(e => e.CL_ATTRIB)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CL_ID)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CL_NM_ENG)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CL_NM_THAI)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CL_NM_USED)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CL_SCM_ID)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CL_SCM_NM)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LASTUPDATE).HasColumnType("datetime");

                entity.Property(e => e.PRN_CL_ID)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SEQ_NO).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.STATUS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.USERID)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<BOT_ISIC>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BOT_ISIC");

                entity.Property(e => e.ATTRIBUTE).HasMaxLength(1);

                entity.Property(e => e.CL_CODE).HasMaxLength(7);

                entity.Property(e => e.CL_FI_CODE).HasMaxLength(7);

                entity.Property(e => e.CL_FM_CODE).HasMaxLength(7);

                entity.Property(e => e.CL_NM_ENG).HasMaxLength(255);

                entity.Property(e => e.CL_NM_THAI).HasMaxLength(255);

                entity.Property(e => e.CL_PCHILD).HasMaxLength(7);

                entity.Property(e => e.LASTUPDATE).HasColumnType("datetime");

                entity.Property(e => e.STATUS).HasMaxLength(1);

                entity.Property(e => e.USERID).HasMaxLength(255);
            });

            modelBuilder.Entity<CustRelateISP>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CustRelateISP");

                entity.Property(e => e.AddDate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AsAtDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BaseName)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CIFNo)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.EndRec)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Filler)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.LastMaDate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.LastMaUser)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.RelatNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RelatSystem)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.RootName)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.RootRefNo)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RunDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RunTime)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Spare)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TransStatus)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.UDATA_DT)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.UDATA_TM)
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IBAFTX180105>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("IBAFTX180105");

                entity.Property(e => e.ACCDCounterpartyType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ACCDLicenseScheme)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalDocumentDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalDocumentNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AsAtDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BeneficiaryOrSenderName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BotReferenceNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BuyAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BuyCurrencyID)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CentralId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryIdOfBeneficiaryOrSender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerInvestmentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DebtInstrumentIssuedAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DebtInstrumentIssuedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExchangeRate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExercisingInvolvedPartyBrNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExercisingInvolvedPartyBusinessType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExercisingInvolvedPartyIBFIndicator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExercisingInvolvedPartyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FIArrangementNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FXTradingTransactionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstDisbursementDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstInstallmentDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromToAccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromToFICode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromToRelatedTransactionDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromTransactionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FxArrangementType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InFlowTransactionPurpose)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstallmentTerm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstallmentTermUnit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InterestRate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InterestRateMargin)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InterestRateType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InvestmentRepatriatedReason)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KeyInTimestamp)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ListedinMarketFlag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoanDeclarationType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaturityDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NotionalAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NotionalCurrencyID)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberofInstallments)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberofShares)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ObjectiveType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherTransactionPurposeDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OutflowTransactionPurpose)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OutstandingNotionalAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OutstandingNotionalCurrencyID)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParvalueperShare)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodFlag_)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PeriodFlag ");

                entity.Property(e => e.RelatedInvolvedPartyBusinessType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RelatedInvolvedPartyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RelationshipWithBeneficiaryOrSender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RelationshipwithRelatedInvolvedPart)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RepaymentDueIndicator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RunDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RunTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SellAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SellCurrencyID)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.System_)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("System ");

                entity.Property(e => e.Term)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TermRange)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TermUnit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToTransactionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionPurposeCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnderlyingOwnerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WholePartialRepaymentFlag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YTDAccumulatedAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IBBFTX180105>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("IBBFTX180105");

                entity.Property(e => e.ACCDCounterpartyType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ACCDLicenseScheme)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalDocumentDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalDocumentNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AsAtDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BeneficiaryOrSenderName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BotReferenceNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BuyAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BuyCurrencyID)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CentralId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryIdOfBeneficiaryOrSender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerInvestmentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DebtInstrumentIssuedAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DebtInstrumentIssuedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExchangeRate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExercisingInvolvedPartyBrNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExercisingInvolvedPartyBusinessType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExercisingInvolvedPartyIBFIndicator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExercisingInvolvedPartyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FIArrangementNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FXTradingTransactionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstDisbursementDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstInstallmentDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromToAccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromToFICode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromToRelatedTransactionDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromTransactionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FxArrangementType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InFlowTransactionPurpose)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstallmentTerm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstallmentTermUnit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InterestRate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InterestRateMargin)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InterestRateType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InvestmentRepatriatedReason)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KeyInTimestamp)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ListedinMarketFlag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoanDeclarationType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaturityDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NotionalAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NotionalCurrencyID)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberofInstallments)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberofShares)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ObjectiveType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherTransactionPurposeDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OutflowTransactionPurpose)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OutstandingNotionalAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OutstandingNotionalCurrencyID)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParvalueperShare)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodFlag_)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PeriodFlag ");

                entity.Property(e => e.RelatedInvolvedPartyBusinessType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RelatedInvolvedPartyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RelationshipWithBeneficiaryOrSender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RelationshipwithRelatedInvolvedPart)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RepaymentDueIndicator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RunDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RunTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SellAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SellCurrencyID)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.System)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Term)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TermRange)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TermUnit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToTransactionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionPurposeCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnderlyingOwnerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WholePartialRepaymentFlag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YTDAccumulatedAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IBBFTX1801052>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("IBBFTX1801052");

                entity.Property(e => e.Column_0)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 0");

                entity.Property(e => e.Column_1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 1");

                entity.Property(e => e.Column_10)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 10");

                entity.Property(e => e.Column_11)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 11");

                entity.Property(e => e.Column_12)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 12");

                entity.Property(e => e.Column_13)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 13");

                entity.Property(e => e.Column_14)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 14");

                entity.Property(e => e.Column_15)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 15");

                entity.Property(e => e.Column_16)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 16");

                entity.Property(e => e.Column_17)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 17");

                entity.Property(e => e.Column_18)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 18");

                entity.Property(e => e.Column_19)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 19");

                entity.Property(e => e.Column_2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 2");

                entity.Property(e => e.Column_20)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 20");

                entity.Property(e => e.Column_21)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 21");

                entity.Property(e => e.Column_22)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 22");

                entity.Property(e => e.Column_23)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 23");

                entity.Property(e => e.Column_24)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 24");

                entity.Property(e => e.Column_25)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 25");

                entity.Property(e => e.Column_26)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 26");

                entity.Property(e => e.Column_27)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 27");

                entity.Property(e => e.Column_28)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 28");

                entity.Property(e => e.Column_29)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 29");

                entity.Property(e => e.Column_3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 3");

                entity.Property(e => e.Column_30)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 30");

                entity.Property(e => e.Column_31)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 31");

                entity.Property(e => e.Column_32)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 32");

                entity.Property(e => e.Column_33)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 33");

                entity.Property(e => e.Column_34)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 34");

                entity.Property(e => e.Column_35)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 35");

                entity.Property(e => e.Column_36)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 36");

                entity.Property(e => e.Column_37)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 37");

                entity.Property(e => e.Column_38)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 38");

                entity.Property(e => e.Column_39)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 39");

                entity.Property(e => e.Column_4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 4");

                entity.Property(e => e.Column_40)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 40");

                entity.Property(e => e.Column_41)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 41");

                entity.Property(e => e.Column_42)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 42");

                entity.Property(e => e.Column_43)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 43");

                entity.Property(e => e.Column_44)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 44");

                entity.Property(e => e.Column_45)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 45");

                entity.Property(e => e.Column_46)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 46");

                entity.Property(e => e.Column_47)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 47");

                entity.Property(e => e.Column_48)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 48");

                entity.Property(e => e.Column_49)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 49");

                entity.Property(e => e.Column_5)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 5");

                entity.Property(e => e.Column_50)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 50");

                entity.Property(e => e.Column_51)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 51");

                entity.Property(e => e.Column_52)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 52");

                entity.Property(e => e.Column_53)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 53");

                entity.Property(e => e.Column_54)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 54");

                entity.Property(e => e.Column_55)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 55");

                entity.Property(e => e.Column_56)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 56");

                entity.Property(e => e.Column_57)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 57");

                entity.Property(e => e.Column_58)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 58");

                entity.Property(e => e.Column_59)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 59");

                entity.Property(e => e.Column_6)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 6");

                entity.Property(e => e.Column_60)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 60");

                entity.Property(e => e.Column_61)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 61");

                entity.Property(e => e.Column_62)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 62");

                entity.Property(e => e.Column_63)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 63");

                entity.Property(e => e.Column_64)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 64");

                entity.Property(e => e.Column_65)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 65");

                entity.Property(e => e.Column_66)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 66");

                entity.Property(e => e.Column_67)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 67");

                entity.Property(e => e.Column_68)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 68");

                entity.Property(e => e.Column_69)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 69");

                entity.Property(e => e.Column_7)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 7");

                entity.Property(e => e.Column_70)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 70");

                entity.Property(e => e.Column_8)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 8");

                entity.Property(e => e.Column_9)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Column 9");
            });

            modelBuilder.Entity<IBCFTX180105>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("IBCFTX180105");

                entity.Property(e => e.ACCDCounterpartyType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ACCDLicenseScheme)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalDocumentDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalDocumentNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AsAtDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BeneficiaryOrSenderName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BotReferenceNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BuyAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BuyCurrencyID)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CentralId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryIdOfBeneficiaryOrSender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerInvestmentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DebtInstrumentIssuedAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DebtInstrumentIssuedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExchangeRate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExercisingInvolvedPartyBrNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExercisingInvolvedPartyBusinessType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExercisingInvolvedPartyIBFIndicator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExercisingInvolvedPartyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FIArrangementNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FXTradingTransactionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstDisbursementDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstInstallmentDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromToAccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromToFICode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromToRelatedTransactionDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromTransactionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FxArrangementType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InFlowTransactionPurpose)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstallmentTerm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstallmentTermUnit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InterestRate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InterestRateMargin)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InterestRateType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InvestmentRepatriatedReason)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KeyInTimestamp)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ListedinMarketFlag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoanDeclarationType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaturityDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NotionalAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NotionalCurrencyID)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberofInstallments)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberofShares)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ObjectiveType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherTransactionPurposeDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OutflowTransactionPurpose)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OutstandingNotionalAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OutstandingNotionalCurrencyID)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParvalueperShare)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodFlag_)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PeriodFlag ");

                entity.Property(e => e.RelatedInvolvedPartyBusinessType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RelatedInvolvedPartyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RelationshipWithBeneficiaryOrSender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RelationshipwithRelatedInvolvedPart)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RepaymentDueIndicator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RunDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RunTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SellAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SellCurrencyID)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.System)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Term)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TermRange)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TermUnit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToTransactionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionPurposeCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnderlyingOwnerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WholePartialRepaymentFlag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YTDAccumulatedAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable("IdentityRole", "security");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<IdentityUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_security.IdentityUsers");

                entity.ToTable("IdentityUser", "security");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<IdentityUserClaim>(entity =>
            {
                entity.ToTable("IdentityUserClaim", "security");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.IdentityUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_IdentityUserClaim_IdentityUser");
            });

            modelBuilder.Entity<IdentityUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_security.IdentityUserLogins");

                entity.ToTable("IdentityUserLogin", "security");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.IdentityUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdentityUserLogin_IdentityUser");
            });

            modelBuilder.Entity<IdentityUserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("IdentityUserProfile", "security");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.IdentityUserProfile)
                    .HasForeignKey<IdentityUserProfile>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdentityUserProfile_IdentityUser");
            });

            modelBuilder.Entity<IdentityUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_security.IdentityUserRoles");

                entity.ToTable("IdentityUserRole", "security");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.IdentityUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdentityUserRole_IdentityRole");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.IdentityUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdentityUserRole_IdentityUser");
            });

            modelBuilder.Entity<Load_LimitColl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Load_LimitColl");
            });

            modelBuilder.Entity<SCL>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SCL");

                entity.Property(e => e.BankNumber)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('''')");

                entity.Property(e => e.CustName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DataAsOfDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EffectiveDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ErrorDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExpiredDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Filler)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Hold_Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.InterfaceNumber)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LimitAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.LimitAvailable).HasDefaultValueSql("((0))");

                entity.Property(e => e.LimitCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('''')");

                entity.Property(e => e.LimitDescription)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LimitName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LimitNumber)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LimitUtilisation).HasDefaultValueSql("((0))");

                entity.Property(e => e.OutBalTHB).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessStatus)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProcessTime)
                    .HasMaxLength(26)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessingDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecordType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Share_Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.SystemID)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<SCV>(entity =>
            {
                entity.HasKey(e => e.ReferenceNumber);

                entity.ToTable("SCV");

                entity.Property(e => e.ReferenceNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AccruedInterestAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.AgingInterestDay).HasDefaultValueSql("((0))");

                entity.Property(e => e.AgingPricipleDay).HasDefaultValueSql("((0))");

                entity.Property(e => e.ApprovedLimitAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.BOTPurposecode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BaseRate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BookingBranchCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BusinessSizeBOT)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CCS_LmType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreatetBy)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CurrencyID)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DataAsOfDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DeferredIncomeAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.DisbursementAmountFCY).HasDefaultValueSql("((0))");

                entity.Property(e => e.DisbursementAmountLCY).HasDefaultValueSql("((0))");

                entity.Property(e => e.DisbursementDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DiscountRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EntityCode1P)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ErrorDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FacNo)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FeeCommissionAmountLTD).HasDefaultValueSql("((0))");

                entity.Property(e => e.Filler)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FlagDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ISP_Module)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IntRateCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InterfaceNumber)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LimitNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MaturityDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Module)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutstandingAmountFCY).HasDefaultValueSql("((0))");

                entity.Property(e => e.OutstandingAmountLCY).HasDefaultValueSql("((0))");

                entity.Property(e => e.PaidIntAccr).HasDefaultValueSql("((0))");

                entity.Property(e => e.PaidIntIncome).HasDefaultValueSql("((0))");

                entity.Property(e => e.PaidM).HasDefaultValueSql("((0))");

                entity.Property(e => e.PaidMemoAccr).HasDefaultValueSql("((0))");

                entity.Property(e => e.PaidP).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessStatus)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProcessTime)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProcessingDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductDescription)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductGroupCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RecordType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevalueRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.SpreadCode)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SpreadRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.StopAccruedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StopAccruedFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SuspendedInterestAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.SystemID)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Sheet12_>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Sheet12$");

                entity.Property(e => e.AcAddr).HasMaxLength(255);

                entity.Property(e => e.AcBank).HasMaxLength(255);

                entity.Property(e => e.Allocation).HasMaxLength(255);

                entity.Property(e => e.AppvNo).HasMaxLength(255);

                entity.Property(e => e.AuthCode).HasMaxLength(255);

                entity.Property(e => e.AuthDate).HasColumnType("datetime");

                entity.Property(e => e.AutoOverDue).HasMaxLength(255);

                entity.Property(e => e.BLAdvice).HasMaxLength(255);

                entity.Property(e => e.BLFwd).HasMaxLength(255);

                entity.Property(e => e.BLIntCode).HasMaxLength(255);

                entity.Property(e => e.BLIntStartDate).HasColumnType("datetime");

                entity.Property(e => e.BLNumber).HasMaxLength(255);

                entity.Property(e => e.BenCnty).HasMaxLength(255);

                entity.Property(e => e.BenInfo).HasMaxLength(255);

                entity.Property(e => e.BenName).HasMaxLength(255);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(255);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(255);

                entity.Property(e => e.CFRRate).HasMaxLength(255);

                entity.Property(e => e.ChipAcBank).HasMaxLength(255);

                entity.Property(e => e.ChipInterm).HasMaxLength(255);

                entity.Property(e => e.ChipNego).HasMaxLength(255);

                entity.Property(e => e.CommDesc).HasMaxLength(255);

                entity.Property(e => e.CommExch).HasMaxLength(255);

                entity.Property(e => e.CommFCD).HasMaxLength(255);

                entity.Property(e => e.CustAddr).HasMaxLength(255);

                entity.Property(e => e.CustCode).HasMaxLength(255);

                entity.Property(e => e.DMS).HasMaxLength(255);

                entity.Property(e => e.DateLastAccru).HasColumnType("datetime");

                entity.Property(e => e.DateLastPaid).HasColumnType("datetime");

                entity.Property(e => e.DateStartAccru).HasColumnType("datetime");

                entity.Property(e => e.DateToStop).HasMaxLength(255);

                entity.Property(e => e.DocCCy).HasMaxLength(255);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.Event).HasMaxLength(255);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventFlag).HasMaxLength(255);

                entity.Property(e => e.EventMode).HasMaxLength(255);

                entity.Property(e => e.ExchBefore).HasMaxLength(255);

                entity.Property(e => e.FBCcy).HasMaxLength(255);

                entity.Property(e => e.FCyAcNo).HasMaxLength(255);

                entity.Property(e => e.FCyPayFlag).HasMaxLength(255);

                entity.Property(e => e.FCyReceiptNo).HasMaxLength(255);

                entity.Property(e => e.FacNo).HasMaxLength(255);

                entity.Property(e => e.GenAccFlag).HasMaxLength(255);

                entity.Property(e => e.Goods).HasMaxLength(255);

                entity.Property(e => e.IntBefore).HasMaxLength(255);

                entity.Property(e => e.IntFixDate).HasMaxLength(255);

                entity.Property(e => e.IntFlag).HasMaxLength(255);

                entity.Property(e => e.IntPayType).HasMaxLength(255);

                entity.Property(e => e.IntRateCode).HasMaxLength(255);

                entity.Property(e => e.IntStartDate).HasColumnType("datetime");

                entity.Property(e => e.IntermAddr).HasMaxLength(255);

                entity.Property(e => e.IntermBank).HasMaxLength(255);

                entity.Property(e => e.Invoice).HasMaxLength(255);

                entity.Property(e => e.LCNumber).HasMaxLength(255);

                entity.Property(e => e.LOCode).HasMaxLength(255);

                entity.Property(e => e.LastIntDate).HasColumnType("datetime");

                entity.Property(e => e.LastReceiptNo).HasMaxLength(255);

                entity.Property(e => e.MTNego).HasMaxLength(255);

                entity.Property(e => e.MTType).HasMaxLength(255);

                entity.Property(e => e.Nego799).HasMaxLength(255);

                entity.Property(e => e.Nego999).HasMaxLength(255);

                entity.Property(e => e.NegoBank).HasMaxLength(255);

                entity.Property(e => e.NegoCnty).HasMaxLength(255);

                entity.Property(e => e.NegoRefno).HasMaxLength(255);

                entity.Property(e => e.NegoTelex).HasMaxLength(255);

                entity.Property(e => e.NostACInfo).HasMaxLength(255);

                entity.Property(e => e.OverdueDate).HasMaxLength(255);

                entity.Property(e => e.PastDueDate).HasMaxLength(255);

                entity.Property(e => e.PayFlag).HasMaxLength(255);

                entity.Property(e => e.PayMethod).HasMaxLength(255);

                entity.Property(e => e.PayType).HasMaxLength(255);

                entity.Property(e => e.PrevDueDate).HasMaxLength(255);

                entity.Property(e => e.PrevFBChrg).HasMaxLength(255);

                entity.Property(e => e.PrevFBEng).HasMaxLength(255);

                entity.Property(e => e.PrevFBInt).HasMaxLength(255);

                entity.Property(e => e.RecStatus).HasMaxLength(255);

                entity.Property(e => e.RecType).HasMaxLength(255);

                entity.Property(e => e.RefNumber).HasMaxLength(255);

                entity.Property(e => e.ReimBank).HasMaxLength(255);

                entity.Property(e => e.Relation).HasMaxLength(255);

                entity.Property(e => e.RevAccru).HasMaxLength(255);

                entity.Property(e => e.RevAccruTax).HasMaxLength(255);

                entity.Property(e => e.SGNumber).HasMaxLength(255);

                entity.Property(e => e.SGNumber1).HasMaxLength(255);

                entity.Property(e => e.SettleDate).HasMaxLength(255);

                entity.Property(e => e.SettleFlag).HasMaxLength(255);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TRCCyFlag).HasMaxLength(255);

                entity.Property(e => e.TRCcy).HasMaxLength(255);

                entity.Property(e => e.TRCont2).HasMaxLength(255);

                entity.Property(e => e.TRCont3).HasMaxLength(255);

                entity.Property(e => e.TRCont4).HasMaxLength(255);

                entity.Property(e => e.TRCont5).HasMaxLength(255);

                entity.Property(e => e.TRDueStatus).HasMaxLength(255);

                entity.Property(e => e.TRFLAG).HasMaxLength(255);

                entity.Property(e => e.TRNumber).HasMaxLength(255);

                entity.Property(e => e.TRRate).HasMaxLength(255);

                entity.Property(e => e.TRStatus).HasMaxLength(255);

                entity.Property(e => e.TaxRefund).HasMaxLength(255);

                entity.Property(e => e.TenorType).HasMaxLength(255);

                entity.Property(e => e.Tx23E).HasMaxLength(255);

                entity.Property(e => e.Tx26).HasMaxLength(255);

                entity.Property(e => e.Tx59A).HasMaxLength(255);

                entity.Property(e => e.Tx59Cnty).HasMaxLength(255);

                entity.Property(e => e.Tx59D).HasMaxLength(255);

                entity.Property(e => e.Tx71A).HasMaxLength(255);

                entity.Property(e => e.Tx72).HasMaxLength(255);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(255);

                entity.Property(e => e.ValueDate).HasMaxLength(255);
            });

            modelBuilder.Entity<Sheet1_>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Sheet1$");

                entity.Property(e => e.AccAmt1).HasMaxLength(255);

                entity.Property(e => e.AccAmt2).HasMaxLength(255);

                entity.Property(e => e.AccAmt3).HasMaxLength(255);

                entity.Property(e => e.AccNo1).HasMaxLength(255);

                entity.Property(e => e.AccNo2).HasMaxLength(255);

                entity.Property(e => e.AccNo3).HasMaxLength(255);

                entity.Property(e => e.Allocation).HasMaxLength(255);

                entity.Property(e => e.AuthCode).HasMaxLength(255);

                entity.Property(e => e.AuthDate).HasMaxLength(255);

                entity.Property(e => e.CenterID).HasMaxLength(255);

                entity.Property(e => e.ChqBank).HasMaxLength(255);

                entity.Property(e => e.ChqBran).HasMaxLength(255);

                entity.Property(e => e.ChqNo).HasMaxLength(255);

                entity.Property(e => e.CommBnet).HasMaxLength(255);

                entity.Property(e => e.CommCertify).HasMaxLength(255);

                entity.Property(e => e.CommFCD).HasMaxLength(255);

                entity.Property(e => e.CommOther).HasMaxLength(255);

                entity.Property(e => e.CurrentAmt).HasMaxLength(255);

                entity.Property(e => e.CustCode).HasMaxLength(255);

                entity.Property(e => e.DateLastPaid).HasMaxLength(255);

                entity.Property(e => e.DueDate).HasMaxLength(255);

                entity.Property(e => e.EventDate).HasMaxLength(255);

                entity.Property(e => e.ExchRate).HasMaxLength(255);

                entity.Property(e => e.ExchRate2).HasMaxLength(255);

                entity.Property(e => e.F100).HasMaxLength(255);

                entity.Property(e => e.F101).HasMaxLength(255);

                entity.Property(e => e.F102).HasMaxLength(255);

                entity.Property(e => e.F103).HasMaxLength(255);

                entity.Property(e => e.F74).HasMaxLength(255);

                entity.Property(e => e.F75).HasMaxLength(255);

                entity.Property(e => e.F76).HasMaxLength(255);

                entity.Property(e => e.F77).HasMaxLength(255);

                entity.Property(e => e.F78).HasMaxLength(255);

                entity.Property(e => e.F79).HasMaxLength(255);

                entity.Property(e => e.F80).HasMaxLength(255);

                entity.Property(e => e.F81).HasMaxLength(255);

                entity.Property(e => e.F82).HasMaxLength(255);

                entity.Property(e => e.F83).HasMaxLength(255);

                entity.Property(e => e.F84).HasMaxLength(255);

                entity.Property(e => e.F85).HasMaxLength(255);

                entity.Property(e => e.F86).HasMaxLength(255);

                entity.Property(e => e.F87).HasMaxLength(255);

                entity.Property(e => e.F88).HasMaxLength(255);

                entity.Property(e => e.F89).HasMaxLength(255);

                entity.Property(e => e.F90).HasMaxLength(255);

                entity.Property(e => e.F91).HasMaxLength(255);

                entity.Property(e => e.F92).HasMaxLength(255);

                entity.Property(e => e.F93).HasMaxLength(255);

                entity.Property(e => e.F94).HasMaxLength(255);

                entity.Property(e => e.F95).HasMaxLength(255);

                entity.Property(e => e.F96).HasMaxLength(255);

                entity.Property(e => e.F97).HasMaxLength(255);

                entity.Property(e => e.F98).HasMaxLength(255);

                entity.Property(e => e.F99).HasMaxLength(255);

                entity.Property(e => e.FcdAccNo).HasMaxLength(255);

                entity.Property(e => e.FcdAccTerm).HasMaxLength(255);

                entity.Property(e => e.FcdAmt).HasMaxLength(255);

                entity.Property(e => e.FcdBalance).HasMaxLength(255);

                entity.Property(e => e.FcdCcy).HasMaxLength(255);

                entity.Property(e => e.FcdCross).HasMaxLength(255);

                entity.Property(e => e.FcdEntryDate).HasMaxLength(255);

                entity.Property(e => e.FcdInterest).HasMaxLength(255);

                entity.Property(e => e.FlagReverse).HasMaxLength(255);

                entity.Property(e => e.ForwardNo).HasMaxLength(255);

                entity.Property(e => e.FromDate).HasMaxLength(255);

                entity.Property(e => e.GoodsCode).HasMaxLength(255);

                entity.Property(e => e.HoldAmt).HasMaxLength(255);

                entity.Property(e => e.IntAmt).HasMaxLength(255);

                entity.Property(e => e.IntRate).HasMaxLength(255);

                entity.Property(e => e.IntSpread).HasMaxLength(255);

                entity.Property(e => e.LastReceiptNo).HasMaxLength(255);

                entity.Property(e => e.MaintenAmt).HasMaxLength(255);

                entity.Property(e => e.Mixpayment).HasMaxLength(255);

                entity.Property(e => e.PayFlag).HasMaxLength(255);

                entity.Property(e => e.Paytype).HasMaxLength(255);

                entity.Property(e => e.PrevFcdBal).HasMaxLength(255);

                entity.Property(e => e.ProfitAmt).HasMaxLength(255);

                entity.Property(e => e.PurposeCode).HasMaxLength(255);

                entity.Property(e => e.RecStatus).HasMaxLength(255);

                entity.Property(e => e.ReceiptNo).HasMaxLength(255);

                entity.Property(e => e.RefAccount).HasMaxLength(255);

                entity.Property(e => e.RefTranDoc).HasMaxLength(255);

                entity.Property(e => e.RelateCode).HasMaxLength(255);

                entity.Property(e => e.Remark).HasMaxLength(255);

                entity.Property(e => e.THBBal).HasMaxLength(255);

                entity.Property(e => e.TaxAmt).HasMaxLength(255);

                entity.Property(e => e.TaxRefund).HasMaxLength(255);

                entity.Property(e => e.ToDate).HasMaxLength(255);

                entity.Property(e => e.TranChquAmt).HasMaxLength(255);

                entity.Property(e => e.TranCode).HasMaxLength(255);

                entity.Property(e => e.TranDept).HasMaxLength(255);

                entity.Property(e => e.TranDoc).HasMaxLength(255);

                entity.Property(e => e.TranDrAmt).HasMaxLength(255);

                entity.Property(e => e.TranFCashAmt).HasMaxLength(255);

                entity.Property(e => e.TranFDepos).HasMaxLength(255);

                entity.Property(e => e.TranFMethod).HasMaxLength(255);

                entity.Property(e => e.TranFTel).HasMaxLength(255);

                entity.Property(e => e.TranFcdAmt).HasMaxLength(255);

                entity.Property(e => e.TranFcdStatus).HasMaxLength(255);

                entity.Property(e => e.TranSeqNo).HasMaxLength(255);

                entity.Property(e => e.UpdateDate).HasMaxLength(255);

                entity.Property(e => e.UserCode).HasMaxLength(255);

                entity.Property(e => e.VoucherID).HasMaxLength(255);
            });

            modelBuilder.Entity<Sheet22_>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Sheet22$");

                entity.Property(e => e.AOCode).HasMaxLength(255);

                entity.Property(e => e.AcAddr).HasMaxLength(255);

                entity.Property(e => e.AcBank).HasMaxLength(255);

                entity.Property(e => e.AppvNo).HasMaxLength(255);

                entity.Property(e => e.AuthCode).HasMaxLength(255);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AutoOverDue).HasMaxLength(255);

                entity.Property(e => e.BLAdvice).HasMaxLength(255);

                entity.Property(e => e.BLBalance).HasMaxLength(255);

                entity.Property(e => e.BLBase).HasMaxLength(255);

                entity.Property(e => e.BLDay).HasMaxLength(255);

                entity.Property(e => e.BLExch).HasMaxLength(255);

                entity.Property(e => e.BLFwd).HasMaxLength(255);

                entity.Property(e => e.BLIntAmt).HasMaxLength(255);

                entity.Property(e => e.BLIntCode).HasMaxLength(255);

                entity.Property(e => e.BLIntRate).HasMaxLength(255);

                entity.Property(e => e.BLIntStartDate).HasMaxLength(255);

                entity.Property(e => e.BLInterest).HasMaxLength(255);

                entity.Property(e => e.BLNumber).HasMaxLength(255);

                entity.Property(e => e.BenCnty).HasMaxLength(255);

                entity.Property(e => e.BenInfo).HasMaxLength(255);

                entity.Property(e => e.BenName).HasMaxLength(255);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(255);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(255);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(255);

                entity.Property(e => e.CCS_LmType).HasMaxLength(255);

                entity.Property(e => e.CFRRate).HasMaxLength(255);

                entity.Property(e => e.CenterID).HasMaxLength(255);

                entity.Property(e => e.ChipAcBank).HasMaxLength(255);

                entity.Property(e => e.ChipInterm).HasMaxLength(255);

                entity.Property(e => e.ChipNego).HasMaxLength(255);

                entity.Property(e => e.CommDesc).HasMaxLength(255);

                entity.Property(e => e.CustAddr).HasMaxLength(255);

                entity.Property(e => e.CustCode).HasMaxLength(255);

                entity.Property(e => e.DMS).HasMaxLength(255);

                entity.Property(e => e.DateLastAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateLastPaid).HasColumnType("smalldatetime");

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateToStop).HasColumnType("smalldatetime");

                entity.Property(e => e.DeductComm).HasMaxLength(255);

                entity.Property(e => e.DeductOther).HasMaxLength(255);

                entity.Property(e => e.DeductSwift).HasMaxLength(255);

                entity.Property(e => e.DocCCy).HasMaxLength(255);

                entity.Property(e => e.DueDate).HasMaxLength(255);

                entity.Property(e => e.Event).HasMaxLength(255);

                entity.Property(e => e.EventDate).HasMaxLength(255);

                entity.Property(e => e.EventFlag).HasMaxLength(255);

                entity.Property(e => e.EventMode).HasMaxLength(255);

                entity.Property(e => e.FBCcy).HasMaxLength(255);

                entity.Property(e => e.FBCharge).HasMaxLength(255);

                entity.Property(e => e.FBEngage).HasMaxLength(255);

                entity.Property(e => e.FBInterest).HasMaxLength(255);

                entity.Property(e => e.FCyAcNo).HasMaxLength(255);

                entity.Property(e => e.FCyPayFlag).HasMaxLength(255);

                entity.Property(e => e.FCyReceiptNo).HasMaxLength(255);

                entity.Property(e => e.FacNo).HasMaxLength(255);

                entity.Property(e => e.GenAccFlag).HasMaxLength(255);

                entity.Property(e => e.Goods).HasMaxLength(255);

                entity.Property(e => e.IntFixDate).HasMaxLength(255);

                entity.Property(e => e.IntFlag).HasMaxLength(255);

                entity.Property(e => e.IntPayType).HasMaxLength(255);

                entity.Property(e => e.IntRateCode).HasMaxLength(255);

                entity.Property(e => e.IntStartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.IntermAddr).HasMaxLength(255);

                entity.Property(e => e.IntermBank).HasMaxLength(255);

                entity.Property(e => e.Invoice).HasMaxLength(255);

                entity.Property(e => e.LCNumber).HasMaxLength(255);

                entity.Property(e => e.LOCode).HasMaxLength(255);

                entity.Property(e => e.LastIntDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LastReceiptNo).HasMaxLength(255);

                entity.Property(e => e.MTNego).HasMaxLength(255);

                entity.Property(e => e.MTType).HasMaxLength(255);

                entity.Property(e => e.MidRate).HasMaxLength(255);

                entity.Property(e => e.Nego799).HasMaxLength(255);

                entity.Property(e => e.Nego999).HasMaxLength(255);

                entity.Property(e => e.NegoBank).HasMaxLength(255);

                entity.Property(e => e.NegoCnty).HasMaxLength(255);

                entity.Property(e => e.NegoRefno).HasMaxLength(255);

                entity.Property(e => e.NegoTelex).HasMaxLength(255);

                entity.Property(e => e.NewAccruAmt).HasMaxLength(255);

                entity.Property(e => e.NewAccruCcy).HasMaxLength(255);

                entity.Property(e => e.NostACInfo).HasMaxLength(255);

                entity.Property(e => e.OverdueDate).HasMaxLength(255);

                entity.Property(e => e.PastDueDate).HasMaxLength(255);

                entity.Property(e => e.PayFlag).HasMaxLength(255);

                entity.Property(e => e.PayMethod).HasMaxLength(255);

                entity.Property(e => e.PayType).HasMaxLength(255);

                entity.Property(e => e.PrevDueDate).HasMaxLength(255);

                entity.Property(e => e.PrevFBChrg).HasMaxLength(255);

                entity.Property(e => e.PrevFBEng).HasMaxLength(255);

                entity.Property(e => e.PrevFBInt).HasMaxLength(255);

                entity.Property(e => e.RecStatus).HasMaxLength(255);

                entity.Property(e => e.RecType).HasMaxLength(255);

                entity.Property(e => e.RefNumber).HasMaxLength(255);

                entity.Property(e => e.ReimBank).HasMaxLength(255);

                entity.Property(e => e.Relation).HasMaxLength(255);

                entity.Property(e => e.RevAccru).HasMaxLength(255);

                entity.Property(e => e.RevAccruTax).HasMaxLength(255);

                entity.Property(e => e.SGNumber).HasMaxLength(255);

                entity.Property(e => e.SGNumber1).HasMaxLength(255);

                entity.Property(e => e.SettleDate).HasMaxLength(255);

                entity.Property(e => e.SettleFlag).HasMaxLength(255);

                entity.Property(e => e.StartDate).HasMaxLength(255);

                entity.Property(e => e.TRAmount).HasMaxLength(255);

                entity.Property(e => e.TRAmt2).HasMaxLength(255);

                entity.Property(e => e.TRAmt3).HasMaxLength(255);

                entity.Property(e => e.TRAmt4).HasMaxLength(255);

                entity.Property(e => e.TRAmt5).HasMaxLength(255);

                entity.Property(e => e.TRBalance).HasMaxLength(255);

                entity.Property(e => e.TRCCyFlag).HasMaxLength(255);

                entity.Property(e => e.TRCcy).HasMaxLength(255);

                entity.Property(e => e.TRCcy2).HasMaxLength(255);

                entity.Property(e => e.TRCcy3).HasMaxLength(255);

                entity.Property(e => e.TRCcy4).HasMaxLength(255);

                entity.Property(e => e.TRCcy5).HasMaxLength(255);

                entity.Property(e => e.TRCont1).HasMaxLength(255);

                entity.Property(e => e.TRCont2).HasMaxLength(255);

                entity.Property(e => e.TRCont3).HasMaxLength(255);

                entity.Property(e => e.TRCont4).HasMaxLength(255);

                entity.Property(e => e.TRCont5).HasMaxLength(255);

                entity.Property(e => e.TRDay).HasMaxLength(255);

                entity.Property(e => e.TRDueStatus).HasMaxLength(255);

                entity.Property(e => e.TRExch2).HasMaxLength(255);

                entity.Property(e => e.TRExch3).HasMaxLength(255);

                entity.Property(e => e.TRExch4).HasMaxLength(255);

                entity.Property(e => e.TRExch5).HasMaxLength(255);

                entity.Property(e => e.TRFLAG).HasMaxLength(255);

                entity.Property(e => e.TRNumber).HasMaxLength(255);

                entity.Property(e => e.TRProfit).HasMaxLength(255);

                entity.Property(e => e.TRRate).HasMaxLength(255);

                entity.Property(e => e.TRSeqno).HasMaxLength(255);

                entity.Property(e => e.TRStatus).HasMaxLength(255);

                entity.Property(e => e.TRTermDay).HasMaxLength(255);

                entity.Property(e => e.TaxRefund).HasMaxLength(255);

                entity.Property(e => e.TenorType).HasMaxLength(255);

                entity.Property(e => e.Tx23E).HasMaxLength(255);

                entity.Property(e => e.Tx26).HasMaxLength(255);

                entity.Property(e => e.Tx59A).HasMaxLength(255);

                entity.Property(e => e.Tx59Cnty).HasMaxLength(255);

                entity.Property(e => e.Tx59D).HasMaxLength(255);

                entity.Property(e => e.Tx71A).HasMaxLength(255);

                entity.Property(e => e.Tx72).HasMaxLength(255);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(255);

                entity.Property(e => e.ValueDate).HasMaxLength(255);
            });

            modelBuilder.Entity<TMP_OSCC>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TMP_OSCCS");

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_LMTYPE).HasMaxLength(3);

                entity.Property(e => e.CNAME)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CUSTCODE).HasMaxLength(20);

                entity.Property(e => e.CUST_CIF).HasMaxLength(20);

                entity.Property(e => e.FACNO).HasMaxLength(15);

                entity.Property(e => e.FLAGDUE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MODULE).HasMaxLength(4);

                entity.Property(e => e.TITL)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UPDATE_DATE)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TMP_REPOSGRPCL>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TMP_REPOSGRPCL");

                entity.Property(e => e.BD).HasMaxLength(3);

                entity.Property(e => e.CUST_CODE).HasMaxLength(20);

                entity.Property(e => e.CUST_NAME).HasMaxLength(70);

                entity.Property(e => e.FACNO)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.FLAGDUE).HasMaxLength(1);

                entity.Property(e => e.FLAG_SHARE).HasMaxLength(6);

                entity.Property(e => e.LIMIT_CODE)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.MODULE).HasMaxLength(4);

                entity.Property(e => e.UPDATE_DATE)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.USERCODE)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TMP_SUMACC>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TMP_SUMACC");

                entity.Property(e => e.ACC_CODE)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ACC_NAME)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Busi_Area)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Busi_Line)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CENTERID).HasMaxLength(4);

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.Cost_Center)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustCode).HasMaxLength(20);

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DocNo).HasMaxLength(20);

                entity.Property(e => e.DocNo1).HasMaxLength(35);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ERP_ACC_CODE)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ERP_ACC_NAME)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ERP_INT_ACC_CODE)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ERP_INT_ACC_NAME)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ERP_PROD)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventName).HasMaxLength(25);

                entity.Property(e => e.FlagDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.INT_ACC_CODE)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.INT_ACC_NAME)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KeyNumber).HasMaxLength(35);

                entity.Property(e => e.LOCode)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.LastPayment).HasColumnType("datetime");

                entity.Property(e => e.Module).HasMaxLength(4);

                entity.Property(e => e.OverdueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PastDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PayType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Profit)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RecStatus).HasMaxLength(10);

                entity.Property(e => e.Reference).HasMaxLength(35);

                entity.Property(e => e.Sale_Unit)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.TenorTerm).HasMaxLength(50);

                entity.Property(e => e.TenorType).HasMaxLength(20);

                entity.Property(e => e.UPDATE_DATE)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.USERCODE)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TMP_ViewVolumeCom>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TMP_ViewVolumeCom");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.CustCode).HasMaxLength(8);

                entity.Property(e => e.CustName).HasMaxLength(180);

                entity.Property(e => e.Keynumber).HasMaxLength(20);

                entity.Property(e => e.SendFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TRANEVENT).HasMaxLength(20);

                entity.Property(e => e.TranAccount).HasMaxLength(15);

                entity.Property(e => e.TranCcy).HasMaxLength(3);

                entity.Property(e => e.TranDept).HasMaxLength(4);

                entity.Property(e => e.TranDesc).HasMaxLength(50);

                entity.Property(e => e.TranMod).HasMaxLength(5);

                entity.Property(e => e.TranNature)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TranStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VouchDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<TMP_VolCorrBank>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TMP_VolCorrBank");

                entity.HasIndex(e => new { e.Sec, e.EventName, e.EventDate, e.Module, e.SubModule, e.Reference, e.KeyNumber, e.RepType }, "IX_TMP_VolCorrBank")
                    .IsUnique();

                entity.Property(e => e.BCnty)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BCnty_Name)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BName)
                    .HasMaxLength(140)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BalanceAmt).HasDefaultValueSql("((0))");

                entity.Property(e => e.BhtNet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ccy)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Corr_Bank)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Corr_BankCnty)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Corr_BankName)
                    .HasMaxLength(140)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Corr_CntyName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustCode)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CustName)
                    .HasMaxLength(140)
                    .IsUnicode(false);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KeyNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MT103)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MT202)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Module)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Rate_MidRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.Reference)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.RepType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaveDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Sec)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.SubModule)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SubName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TMP_VolCorrIncome>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TMP_VolCorrIncome");

                entity.HasIndex(e => new { e.VouchDate, e.TranMod, e.KeyNumber, e.Reference, e.CustCode, e.TranAccount, e.RepType, e.BName, e.Corr_Bank, e.Ccy, e.IncomeCcy }, "IX_TMP_VolCorrIncome")
                    .IsUnique();

                entity.Property(e => e.AccName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BCnty)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BName)
                    .HasMaxLength(140)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ccy)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Corr_Bank)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Corr_BankCnty)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Corr_BankName)
                    .HasMaxLength(140)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ERP_Acc_Code)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IncomeCcy)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KeyNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OldModule)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Reference)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RepType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SaveDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TranAccount)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TranMod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VouchDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<TmpATSFile>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TmpATSFile");

                entity.Property(e => e.AccCode)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ApplCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BankCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CompAcc).HasMaxLength(11);

                entity.Property(e => e.DataDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DocMonth)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.EffDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Filler).HasMaxLength(38);

                entity.Property(e => e.RecSeq)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RefReceiver).HasMaxLength(20);

                entity.Property(e => e.RefSender).HasMaxLength(10);

                entity.Property(e => e.ServType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TranAmt)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TranKind)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TmpCCSMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TmpCCSMaster");

                entity.Property(e => e.TAccNo).HasMaxLength(20);

                entity.Property(e => e.TCRType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TCustCode).HasMaxLength(6);

                entity.Property(e => e.TDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TFacNo).HasMaxLength(15);

                entity.Property(e => e.TKeyNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.TModule)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TmpCCSOut>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CCS_AccNo).HasMaxLength(20);

                entity.Property(e => e.CCS_AsDate)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCS_CRType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCS_Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCS_Cust)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCS_Date).HasColumnType("smalldatetime");

                entity.Property(e => e.CCS_FacNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCS_Module)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TmpCustLSum>(entity =>
            {
                entity.HasKey(e => new { e.Cust_Code, e.Facility_No });

                entity.ToTable("TmpCustLSum");

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.Facility_No).HasMaxLength(13);

                entity.Property(e => e.DBE_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.DBE_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.DLC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.DLC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.EXPC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.EXPC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLS_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLS_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLT_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLT_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBL_Over).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMLC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMLC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMTR_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMTR_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.NLTR_book).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGBC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGBC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGLC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGLC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.XBCC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCP_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCP_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCP_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCP_Book).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TmpCustLiab>(entity =>
            {
                entity.HasKey(e => new { e.Cust_Code, e.Facility_No, e.Currency });

                entity.ToTable("TmpCustLiab");

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.Facility_No).HasMaxLength(13);

                entity.Property(e => e.Currency).HasMaxLength(3);

                entity.Property(e => e.EXPC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.EXPC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLS_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLS_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLT_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLT_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBL_Over).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMLC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMLC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMTR_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMTR_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.NLTR_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGBC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGBC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGLC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGLC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.XBCC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCP_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCP_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCP_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCP_Book).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TmpDMSPTX>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TmpDMSPTX");

                entity.Property(e => e.TAccount).HasMaxLength(15);

                entity.Property(e => e.TCcy).HasMaxLength(3);

                entity.Property(e => e.TDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TDept).HasMaxLength(4);

                entity.Property(e => e.TDesc).HasMaxLength(50);

                entity.Property(e => e.TDocNo).HasMaxLength(15);

                entity.Property(e => e.TEvent).HasMaxLength(20);

                entity.Property(e => e.TMod).HasMaxLength(5);

                entity.Property(e => e.TNature)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TmpExchange>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TmpExchange");

                entity.Property(e => e.TExchBNBuy).HasDefaultValueSql("((0))");

                entity.Property(e => e.TExchBNSell).HasDefaultValueSql("((0))");

                entity.Property(e => e.TExchCcy).HasMaxLength(3);

                entity.Property(e => e.TExchDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TExchTRate1).HasDefaultValueSql("((0))");

                entity.Property(e => e.TExchTRate2).HasDefaultValueSql("((0))");

                entity.Property(e => e.TExchTRate3).HasDefaultValueSql("((0))");

                entity.Property(e => e.TExchTime)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TmpFirstDate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TmpFirstDate");

                entity.Property(e => e.CustCode).HasMaxLength(20);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.FacNo).HasMaxLength(13);
            });

            modelBuilder.Entity<TmpInvoice>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TmpInvoice");

                entity.Property(e => e.CCy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.DocMod).HasMaxLength(4);

                entity.Property(e => e.DocMon).HasMaxLength(7);

                entity.Property(e => e.DocNumer).HasMaxLength(15);

                entity.Property(e => e.DocType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FromDate).HasColumnType("smalldatetime");

                entity.Property(e => e.KeyNumber).HasMaxLength(15);

                entity.Property(e => e.ToDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<TmpMasterGL>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TmpMasterGL");

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CustCode).HasMaxLength(16);

                entity.Property(e => e.EventMode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FacNo).HasMaxLength(20);

                entity.Property(e => e.FlagDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.KeyNumber).HasMaxLength(20);

                entity.Property(e => e.Module).HasMaxLength(4);

                entity.Property(e => e.TenorType).HasMaxLength(20);
            });

            modelBuilder.Entity<TmpMonAccrued>(entity =>
            {
                entity.HasKey(e => new { e.Login, e.DocNo, e.DocMode, e.Seqno });

                entity.ToTable("TmpMonAccrued");

                entity.Property(e => e.Login).HasMaxLength(4);

                entity.Property(e => e.DocNo).HasMaxLength(15);

                entity.Property(e => e.DocMode).HasMaxLength(20);

                entity.Property(e => e.BankType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CalDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.DocBank).HasMaxLength(14);

                entity.Property(e => e.DocCust).HasMaxLength(6);

                entity.Property(e => e.DocNumber).HasMaxLength(15);

                entity.Property(e => e.DocRefer).HasMaxLength(15);

                entity.Property(e => e.IntCode).HasMaxLength(10);

                entity.Property(e => e.IntFrom).HasColumnType("smalldatetime");

                entity.Property(e => e.IntTo).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<TmpMonthInt>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TmpMonthInt");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.DocCust).HasMaxLength(6);

                entity.Property(e => e.DocMonth).HasMaxLength(7);

                entity.Property(e => e.NumToWord).HasMaxLength(250);
            });

            modelBuilder.Entity<TmpONL_LCOut>(entity =>
            {
                entity.HasKey(e => e.LC_Number)
                    .HasName("PK_TmpLCOuts");

                entity.Property(e => e.LC_Number).HasMaxLength(15);

                entity.Property(e => e.ACCESS_ID)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.BenName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Edition_Number)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Expiry_Date)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LC_CCy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Last_Tran_date)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Open_Date)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Trade_ref_Number)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Upload_Date)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TmpONL_LCSWFile>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TmpONL_LCSWFile");

                entity.Property(e => e.LneData).HasMaxLength(500);

                entity.Property(e => e.LneFile).HasMaxLength(20);

                entity.Property(e => e.LneName).HasMaxLength(20);
            });

            modelBuilder.Entity<TmpReveMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TmpReveMaster");

                entity.Property(e => e.TAccNo).HasMaxLength(20);

                entity.Property(e => e.TDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TFlagDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TKeyNumber).HasMaxLength(15);

                entity.Property(e => e.TModule)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TmpReveOut>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TmpReveOut");

                entity.Property(e => e.AccNo).HasMaxLength(20);

                entity.Property(e => e.TDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<TmpRptMail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TmpRptMail");

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.Response).HasMaxLength(500);

                entity.Property(e => e.SendBCC).HasMaxLength(300);

                entity.Property(e => e.SendCC).HasMaxLength(300);

                entity.Property(e => e.SendDate).HasColumnType("smalldatetime");

                entity.Property(e => e.SendFile1).HasMaxLength(100);

                entity.Property(e => e.SendFile2).HasMaxLength(100);

                entity.Property(e => e.SendFile3).HasMaxLength(100);

                entity.Property(e => e.SendFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SendMod).HasMaxLength(10);

                entity.Property(e => e.SendPass).HasMaxLength(100);

                entity.Property(e => e.SendSJB).HasMaxLength(500);

                entity.Property(e => e.SendTO).HasMaxLength(300);

                entity.Property(e => e.SendTime)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.SendUser).HasMaxLength(12);

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<TmpSWIFTIN>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TmpSWIFTIN");

                entity.Property(e => e.FDDetail).HasMaxLength(150);

                entity.Property(e => e.FDFile).HasMaxLength(50);

                entity.Property(e => e.FDMT)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FDUser).HasMaxLength(12);
            });

            modelBuilder.Entity<Tmp_pDailyGL>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Tmp_pDailyGL");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CustCode).HasMaxLength(8);

                entity.Property(e => e.GFMS_Bran).HasMaxLength(4);

                entity.Property(e => e.GFMS_Map).HasMaxLength(11);

                entity.Property(e => e.InvoiceNo).HasMaxLength(15);

                entity.Property(e => e.LoanStat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NostroBank).HasMaxLength(13);

                entity.Property(e => e.ProdCode).HasMaxLength(6);

                entity.Property(e => e.RCCode).HasMaxLength(5);

                entity.Property(e => e.SBUCode).HasMaxLength(4);

                entity.Property(e => e.SendFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Tag20Ref).HasMaxLength(20);

                entity.Property(e => e.TranAccount).HasMaxLength(15);

                entity.Property(e => e.TranAllocate).HasMaxLength(15);

                entity.Property(e => e.TranBran).HasMaxLength(4);

                entity.Property(e => e.TranCcy).HasMaxLength(3);

                entity.Property(e => e.TranCenter).HasMaxLength(4);

                entity.Property(e => e.TranCond).HasMaxLength(20);

                entity.Property(e => e.TranDept).HasMaxLength(4);

                entity.Property(e => e.TranDesc).HasMaxLength(50);

                entity.Property(e => e.TranDocNo).HasMaxLength(15);

                entity.Property(e => e.TranEvent).HasMaxLength(20);

                entity.Property(e => e.TranMod).HasMaxLength(5);

                entity.Property(e => e.TranNature)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TranRef).HasMaxLength(15);

                entity.Property(e => e.TranStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VouchDate).HasColumnType("smalldatetime");

                entity.Property(e => e.VouchID).HasMaxLength(15);

                entity.Property(e => e.Wref_Bank_ID).HasMaxLength(14);
            });

            modelBuilder.Entity<Tmp_pMasterDailyOut>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CCy).HasMaxLength(3);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.FlagDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.GFBCInt).HasMaxLength(10);

                entity.Property(e => e.GFBCOuts).HasMaxLength(10);

                entity.Property(e => e.GFMSAccInt).HasMaxLength(11);

                entity.Property(e => e.GFMSAccOuts).HasMaxLength(11);

                entity.Property(e => e.GFMSBran).HasMaxLength(4);

                entity.Property(e => e.KeyNumber).HasMaxLength(15);

                entity.Property(e => e.LastEvent).HasMaxLength(25);

                entity.Property(e => e.LastPayment).HasColumnType("smalldatetime");

                entity.Property(e => e.LiabType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Module).HasMaxLength(5);

                entity.Property(e => e.OutsDate).HasMaxLength(10);

                entity.Property(e => e.OverdueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PastDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ProdCode).HasMaxLength(5);

                entity.Property(e => e.RCCode).HasMaxLength(5);

                entity.Property(e => e.RMCode).HasMaxLength(10);

                entity.Property(e => e.Reference).HasMaxLength(50);

                entity.Property(e => e.SBUCode).HasMaxLength(5);

                entity.Property(e => e.SubProduct).HasMaxLength(5);

                entity.Property(e => e.TENOR_TYPE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenorDay).HasMaxLength(4);

                entity.Property(e => e.TenorType).HasMaxLength(20);

                entity.Property(e => e.WithOutFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.WithOutType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__User__536C85E5EA97E1A6");

                entity.ToTable("User");

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.GivenName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(20);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__UserLogi__536C85E50AF0E147");

                entity.ToTable("UserLogin");

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<VAuthModule>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VAuthModule");

                entity.Property(e => e.CTL_Desc).HasMaxLength(200);

                entity.Property(e => e.CTL_Name).HasMaxLength(50);

                entity.Property(e => e.CTL_Note1).HasMaxLength(50);

                entity.Property(e => e.CTL_Type).HasMaxLength(10);

                entity.Property(e => e.ModCode)
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.UserID).HasMaxLength(12);
            });

            modelBuilder.Entity<VIEWDCSinterface>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEWDCSinterface");

                entity.Property(e => e.AS400_COLL_NO)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CCS_ACC_NO).HasMaxLength(20);

                entity.Property(e => e.CCS_CUST_CODE).HasMaxLength(20);

                entity.Property(e => e.ISP_FAC_NO)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.NAME).HasMaxLength(70);

                entity.Property(e => e.ORIGINAL_CUST_CODE)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.PID_RID).HasMaxLength(13);

                entity.Property(e => e.SAFE_CIF_NO)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.SAFE_COLL_NO)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VIEWMASTERPENDING>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEWMASTERPENDING");

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.CENTERID).HasMaxLength(4);

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CustCode).HasMaxLength(20);

                entity.Property(e => e.CustName).HasMaxLength(500);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventName).HasMaxLength(30);

                entity.Property(e => e.KeyNumber).HasMaxLength(35);

                entity.Property(e => e.Module).HasMaxLength(5);

                entity.Property(e => e.RecStatus).HasMaxLength(10);

                entity.Property(e => e.Reference).HasMaxLength(35);

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<VIEWTMP14GrpOSCL>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEWTMP14GrpOSCL");

                entity.Property(e => e.CCY).HasMaxLength(3);

                entity.Property(e => e.CUST_CODE).HasMaxLength(20);

                entity.Property(e => e.FACNO).HasMaxLength(15);

                entity.Property(e => e.FLAGDUE)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MODULE).HasMaxLength(15);
            });

            modelBuilder.Entity<VIEWTMP24GrpOSCL>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEWTMP24GrpOSCL");

                entity.Property(e => e.CCY).HasMaxLength(3);

                entity.Property(e => e.CUST_CODE).HasMaxLength(20);

                entity.Property(e => e.FACNO)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.FLAGDUE)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MODULE).HasMaxLength(15);
            });

            modelBuilder.Entity<VIEWTMP34GrpOSCL>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEWTMP34GrpOSCL");

                entity.Property(e => e.CUST_CODE).HasMaxLength(20);

                entity.Property(e => e.FACNO)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.FLAGDUE)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MODULE).HasMaxLength(15);
            });

            modelBuilder.Entity<VIEWTMP44GrpOSCL>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEWTMP44GrpOSCL");

                entity.Property(e => e.BD).HasMaxLength(3);

                entity.Property(e => e.CUST_CODE)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.CUST_NAME).HasMaxLength(70);

                entity.Property(e => e.FACNO)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.FLAGDUE)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FLAG_SHARE).HasMaxLength(6);

                entity.Property(e => e.LIMIT_CODE)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.MODULE)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<VIEWTMPGrpOSCL>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEWTMPGrpOSCL");

                entity.Property(e => e.CUST_CODE).HasMaxLength(20);

                entity.Property(e => e.FACNO)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<VIEWTMPGrpOSCL1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEWTMPGrpOSCL1");

                entity.Property(e => e.CUST_CODE)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.FACNO)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.FLAG_SHARE).HasMaxLength(6);

                entity.Property(e => e.LIMIT_CODE)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<VIEW_LC_INFO>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEW_LC_INFO");

                entity.Property(e => e.ADVBANKCODE)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.ADVNAME)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.AMENDNO)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.BENCNTY)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.BENINFO)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.CCY).HasMaxLength(3);

                entity.Property(e => e.CENTERID).HasMaxLength(4);

                entity.Property(e => e.CUSTCODE).HasMaxLength(20);

                entity.Property(e => e.CUSTNAME).HasMaxLength(70);

                entity.Property(e => e.DUEDATE).HasColumnType("smalldatetime");

                entity.Property(e => e.EVENT).HasMaxLength(25);

                entity.Property(e => e.EVENTDATE).HasColumnType("smalldatetime");

                entity.Property(e => e.GOODSCODE)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.GOOD_DET)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.KEYNUMBER)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PRODUCT)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.REFERENCE)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.STARTDATE).HasColumnType("smalldatetime");

                entity.Property(e => e.STATUS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SWIFT_CODE)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.TENORTYPE).HasMaxLength(20);
            });

            modelBuilder.Entity<VIEW_OSbyCC>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEW_OSbyCCS");

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_LMTYPE).HasMaxLength(3);

                entity.Property(e => e.CCY).HasMaxLength(3);

                entity.Property(e => e.CUSTCODE).HasMaxLength(20);

                entity.Property(e => e.FACNO).HasMaxLength(15);

                entity.Property(e => e.FLAGDUE)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MODULE).HasMaxLength(15);
            });

            modelBuilder.Entity<VIEW_OSbyCCS1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEW_OSbyCCS1");

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_LMTYPE).HasMaxLength(3);

                entity.Property(e => e.CUSTCODE).HasMaxLength(20);

                entity.Property(e => e.FACNO).HasMaxLength(15);

                entity.Property(e => e.FLAGDUE)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MODULE).HasMaxLength(15);
            });

            modelBuilder.Entity<VIEW_REPOSGrpCL>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEW_REPOSGrpCL");

                entity.Property(e => e.BD).HasMaxLength(3);

                entity.Property(e => e.CUST_CODE)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.CUST_NAME).HasMaxLength(70);

                entity.Property(e => e.FACNO)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.FLAGDUE)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FLAG_SHARE).HasMaxLength(6);

                entity.Property(e => e.LIMIT_CODE)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.MODULE)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<ViewARemExchRate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewARemExchRate");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.RemRefNo)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.RmForward).HasMaxLength(15);
            });

            modelBuilder.Entity<ViewAllRemRate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewAllRemRate");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.RemRefNo)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.RmForward).HasMaxLength(15);
            });

            modelBuilder.Entity<ViewAllRemit>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewAllRemit");

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CENTERID).HasMaxLength(4);

                entity.Property(e => e.CustInfo1).HasMaxLength(35);

                entity.Property(e => e.Cust_Bran).HasMaxLength(3);

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RateFlag)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RateRemark)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RateType).HasMaxLength(1);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReceiptNo).HasMaxLength(15);

                entity.Property(e => e.RemBank).HasMaxLength(20);

                entity.Property(e => e.RemCcy).HasMaxLength(3);

                entity.Property(e => e.RemDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RemType)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.RemrefNo)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<ViewBankLimit>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewBankLimit");

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AutoRec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Bank_Code)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.BlockDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Block_Code)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Block_Note).HasMaxLength(350);

                entity.Property(e => e.CCS_No).HasMaxLength(20);

                entity.Property(e => e.Condition).HasMaxLength(150);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Credit_Ccy).HasMaxLength(3);

                entity.Property(e => e.ExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Facility_No)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.Facility_Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_Code).HasMaxLength(10);

                entity.Property(e => e.RecCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Remark).HasMaxLength(350);

                entity.Property(e => e.Revol_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Seq_No)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.UsingRec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ViewCC>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewCCS");

                entity.Property(e => e.CCS_No).HasMaxLength(20);

                entity.Property(e => e.Cust_Code)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Facility_No)
                    .IsRequired()
                    .HasMaxLength(13);
            });

            modelBuilder.Entity<ViewCLBOut>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewCLBOut");

                entity.Property(e => e.AgentName).HasMaxLength(500);

                entity.Property(e => e.BranCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Bran_Name).HasMaxLength(70);

                entity.Property(e => e.CICDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CLCCy).HasMaxLength(3);

                entity.Property(e => e.CLNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Cust_Addr).HasMaxLength(500);

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.Cust_Info).HasMaxLength(35);

                entity.Property(e => e.Description).HasMaxLength(15);

                entity.Property(e => e.Event).HasMaxLength(20);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RecType).HasMaxLength(10);

                entity.Property(e => e.TranStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VoucherID).HasMaxLength(15);
            });

            modelBuilder.Entity<ViewCreditLimit>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewCreditLimit");

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AutoRec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BlockDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Block_Code)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Block_Note).HasMaxLength(350);

                entity.Property(e => e.CCS_No).HasMaxLength(20);

                entity.Property(e => e.CFRRate).HasMaxLength(10);

                entity.Property(e => e.CLMS_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Condition).HasMaxLength(150);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Credit_Ccy).HasMaxLength(3);

                entity.Property(e => e.Cust_Code)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Facility_No)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.Facility_Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_Code).HasMaxLength(10);

                entity.Property(e => e.Parent_Id).HasMaxLength(6);

                entity.Property(e => e.RecCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Refer_Cust).HasMaxLength(6);

                entity.Property(e => e.Refer_Facility).HasMaxLength(13);

                entity.Property(e => e.Remark).HasMaxLength(350);

                entity.Property(e => e.Revol_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Seq_No)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Share_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Share_Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.UsingRec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ViewCreditLimitTmp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewCreditLimitTmp");

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AutoRec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BlockDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Block_Code)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Block_Note).HasMaxLength(350);

                entity.Property(e => e.CCS_No).HasMaxLength(20);

                entity.Property(e => e.CFRRate).HasMaxLength(10);

                entity.Property(e => e.Condition).HasMaxLength(150);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Credit_Ccy).HasMaxLength(3);

                entity.Property(e => e.Cust_Code)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Facility_No)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.Facility_Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_Code).HasMaxLength(10);

                entity.Property(e => e.Parent_Id).HasMaxLength(6);

                entity.Property(e => e.RecCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Refer_Cust).HasMaxLength(6);

                entity.Property(e => e.Refer_Facility).HasMaxLength(13);

                entity.Property(e => e.Remark).HasMaxLength(350);

                entity.Property(e => e.Revol_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Seq_No)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Share_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Share_Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.UsingRec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ViewCustLiab>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewCustLiab");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Cust_Code)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Facility_No)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.Refer_Cust).HasMaxLength(6);

                entity.Property(e => e.Refer_Facility).HasMaxLength(13);

                entity.Property(e => e.Share_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ViewCustLimit>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewCustLimit");

                entity.Property(e => e.CCS_No).HasMaxLength(20);

                entity.Property(e => e.CLMS_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_Code)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Facility_No)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.Limit_DLC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_EXBC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_EXLC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_EXP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_EXPC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_IMEX)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_IMLC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_IMP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_IMTR)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ViewCustShare>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewCustShare");

                entity.Property(e => e.Cust_Code)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Facility_No)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.Facility_Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_Code).HasMaxLength(10);

                entity.Property(e => e.Limit_DLC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_EXBC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_EXLC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_EXP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_EXPC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_IMEX)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_IMLC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_IMP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_IMTR)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Parent_Id).HasMaxLength(6);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Refer_Cust).HasMaxLength(6);

                entity.Property(e => e.Refer_Facility).HasMaxLength(13);

                entity.Property(e => e.Remark).HasMaxLength(350);

                entity.Property(e => e.Revol_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Share_CCS).HasMaxLength(20);

                entity.Property(e => e.Share_Cust).HasMaxLength(6);

                entity.Property(e => e.Share_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Share_Limit).HasMaxLength(10);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ViewDayRemExchRate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewDayRemExchRate");

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.CustInfo1).HasMaxLength(35);

                entity.Property(e => e.Cust_Bran).HasMaxLength(3);

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RateFlag).HasMaxLength(50);

                entity.Property(e => e.RateRemark).HasMaxLength(50);

                entity.Property(e => e.RateType).HasMaxLength(1);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReceiptNo).HasMaxLength(15);

                entity.Property(e => e.RemBank).HasMaxLength(20);

                entity.Property(e => e.RemCcy).HasMaxLength(3);

                entity.Property(e => e.RemDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RemRefNo)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.RemType)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.RmForward).HasMaxLength(15);
            });

            modelBuilder.Entity<ViewDayTran>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewDayTrans");

                entity.Property(e => e.AcceptDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AcceptFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Allocation).HasMaxLength(15);

                entity.Property(e => e.Amend).HasMaxLength(15);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.BCnty).HasMaxLength(3);

                entity.Property(e => e.BName).HasMaxLength(175);

                entity.Property(e => e.BPOFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.COLLECTION)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.Corr_BANK).HasMaxLength(500);

                entity.Property(e => e.Corr_Cnty).HasMaxLength(10);

                entity.Property(e => e.Corr_Name).HasMaxLength(500);

                entity.Property(e => e.CustCode).HasMaxLength(20);

                entity.Property(e => e.CustName).HasMaxLength(500);

                entity.Property(e => e.DNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventFlag)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.EventMode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EventName).HasMaxLength(30);

                entity.Property(e => e.FacNo).HasMaxLength(20);

                entity.Property(e => e.FlagDue)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ISS_BANK)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.KeyNumber)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PayFlag)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.PayMethod)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.RecStatus).HasMaxLength(10);

                entity.Property(e => e.Reference).HasMaxLength(35);

                entity.Property(e => e.Relation)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.RpReceiptNo).HasMaxLength(15);

                entity.Property(e => e.TenorTerm).HasMaxLength(50);

                entity.Property(e => e.TenorType).HasMaxLength(20);

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.WithOutFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.WithOutType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Wref_Bank_ID).HasMaxLength(14);

                entity.Property(e => e.collectrefund).HasMaxLength(25);
            });

            modelBuilder.Entity<ViewExPayment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewExPayment");

                entity.Property(e => e.AGENT_BANK_ID).HasMaxLength(13);

                entity.Property(e => e.ALLOCATION).HasMaxLength(15);

                entity.Property(e => e.AcBahtnet).HasMaxLength(15);

                entity.Property(e => e.BENE_ID).HasMaxLength(13);

                entity.Property(e => e.DOCNUMBER)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.DRAFT_CCY).HasMaxLength(3);

                entity.Property(e => e.Debit_credit_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.EVENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.EVENT_TYPE).HasMaxLength(25);

                entity.Property(e => e.FORWARD_CONRACT_NO1).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO2).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO3).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO4).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO5).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO6).HasMaxLength(15);

                entity.Property(e => e.FcdAcc).HasMaxLength(15);

                entity.Property(e => e.ISSUE_BANK_ID).HasMaxLength(13);

                entity.Property(e => e.Method).HasMaxLength(10);

                entity.Property(e => e.PAYMENT_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.PAYMENT_INSTRU).HasMaxLength(10);

                entity.Property(e => e.PURCH_DISC_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RECEIVED_NO).HasMaxLength(15);

                entity.Property(e => e.RECORD_TYPE)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.REC_STATUS)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.RpChqBank).HasMaxLength(10);

                entity.Property(e => e.RpChqBranch).HasMaxLength(25);

                entity.Property(e => e.RpChqNo).HasMaxLength(15);

                entity.Property(e => e.RpCustAc1).HasMaxLength(15);

                entity.Property(e => e.RpCustAc2).HasMaxLength(15);

                entity.Property(e => e.RpCustAc3).HasMaxLength(15);

                entity.Property(e => e.RpCustCode).HasMaxLength(6);

                entity.Property(e => e.RpDocNo).HasMaxLength(15);

                entity.Property(e => e.RpEvent).HasMaxLength(20);

                entity.Property(e => e.RpModule).HasMaxLength(5);

                entity.Property(e => e.RpPayBy).HasMaxLength(15);

                entity.Property(e => e.RpPayDate).HasColumnType("smalldatetime");

                entity.Property(e => e.SIGHT_FORWARD).HasMaxLength(15);

                entity.Property(e => e.TERM_FORWARD).HasMaxLength(15);

                entity.Property(e => e.fb_ccy).HasMaxLength(3);
            });

            modelBuilder.Entity<ViewFCDout>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewFCDout");

                entity.Property(e => e.CheckLiab)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DepositDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FCDtype)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.FcdAccNo)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.FcdAccType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FcdCcy).HasMaxLength(3);

                entity.Property(e => e.FcdFinInst)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FcdFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FcdResType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FcdSavFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FlagRate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.OpenDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TranDoc)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.TranFFlag).HasMaxLength(5);

                entity.Property(e => e.custcode).HasMaxLength(6);
            });

            modelBuilder.Entity<ViewFCPImport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewFCPImport");

                entity.Property(e => e.ccy).HasMaxLength(3);
            });

            modelBuilder.Entity<ViewFcdAccount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewFcdAccount");

                entity.Property(e => e.Allocation).HasMaxLength(10);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.CustName).HasMaxLength(100);

                entity.Property(e => e.DateLastPaid).HasColumnType("smalldatetime");

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Expr2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FcdAccName).HasMaxLength(70);

                entity.Property(e => e.FcdAccNo)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.FcdAccType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FcdCcy).HasMaxLength(3);

                entity.Property(e => e.FcdCcyName).HasMaxLength(50);

                entity.Property(e => e.FcdEntryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FcdSavFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FcdStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.HoldFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastReceiptNo).HasMaxLength(15);

                entity.Property(e => e.Maturity).HasColumnType("smalldatetime");

                entity.Property(e => e.OpenDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Paytype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReceiptNo).HasMaxLength(15);

                entity.Property(e => e.RefAccount).HasMaxLength(35);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.TaxRefund)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TranCode).HasMaxLength(25);

                entity.Property(e => e.TranDept).HasMaxLength(3);

                entity.Property(e => e.TranDoc)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.TranFFlag).HasMaxLength(5);

                entity.Property(e => e.TranFMethod).HasMaxLength(15);

                entity.Property(e => e.TranFcdStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.VoucherID).HasMaxLength(15);
            });

            modelBuilder.Entity<ViewGENDLC>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewGENDLC");

                entity.Property(e => e.Allocation).HasMaxLength(13);

                entity.Property(e => e.AmendFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.Event).HasMaxLength(25);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FCYRec).HasMaxLength(15);

                entity.Property(e => e.KeyNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastReceiptNo).HasMaxLength(15);

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayMentFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Paymethod).HasMaxLength(15);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VoucherID).HasMaxLength(15);
            });

            modelBuilder.Entity<ViewGenACC>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewGenACC");

                entity.Property(e => e.ACcy).HasMaxLength(255);

                entity.Property(e => e.AEvent).HasMaxLength(255);

                entity.Property(e => e.AModule).HasMaxLength(255);

                entity.Property(e => e.AName).HasMaxLength(255);

                entity.Property(e => e.ANature).HasMaxLength(255);

                entity.Property(e => e.ASeq).HasMaxLength(255);

                entity.Property(e => e.Acc_Map).HasMaxLength(15);

                entity.Property(e => e.Accode).HasMaxLength(255);
            });

            modelBuilder.Entity<ViewGroupGL>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewGroupGL");

                entity.Property(e => e.TranAccount).HasMaxLength(15);

                entity.Property(e => e.TranAllocate).HasMaxLength(15);

                entity.Property(e => e.TranCcy).HasMaxLength(3);

                entity.Property(e => e.TranCenter).HasMaxLength(4);

                entity.Property(e => e.TranDept).HasMaxLength(4);

                entity.Property(e => e.TranEvent).HasMaxLength(20);

                entity.Property(e => e.TranMod).HasMaxLength(5);

                entity.Property(e => e.TranNature)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VouchDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<ViewLastExchRate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewLastExchRate");

                entity.Property(e => e.Exch_Ccy)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Exch_Date).HasColumnType("smalldatetime");

                entity.Property(e => e.Exch_Time)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ViewMapAccount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewMapAccount");

                entity.Property(e => e.Acc_Code)
                    .IsRequired()
                    .HasMaxLength(19);

                entity.Property(e => e.Acc_Name).HasMaxLength(100);

                entity.Property(e => e.mAcc_BsLine).HasMaxLength(10);

                entity.Property(e => e.mAcc_BuArea).HasMaxLength(4);

                entity.Property(e => e.mAcc_Cond).HasMaxLength(1);

                entity.Property(e => e.mAcc_Cost).HasMaxLength(10);

                entity.Property(e => e.mAcc_Mod).HasMaxLength(5);

                entity.Property(e => e.mAcc_New).HasMaxLength(19);

                entity.Property(e => e.mAcc_Profit).HasMaxLength(10);

                entity.Property(e => e.mAcc_Type).HasMaxLength(15);
            });

            modelBuilder.Entity<ViewMapDailyGL>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewMapDailyGL");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CustCode).HasMaxLength(8);

                entity.Property(e => e.SendFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TranAccount).HasMaxLength(15);

                entity.Property(e => e.TranAllocate).HasMaxLength(15);

                entity.Property(e => e.TranBSArea).HasMaxLength(4);

                entity.Property(e => e.TranBSLine).HasMaxLength(10);

                entity.Property(e => e.TranBran).HasMaxLength(4);

                entity.Property(e => e.TranCcy).HasMaxLength(3);

                entity.Property(e => e.TranCenter).HasMaxLength(4);

                entity.Property(e => e.TranCond).HasMaxLength(20);

                entity.Property(e => e.TranCost).HasMaxLength(10);

                entity.Property(e => e.TranDept).HasMaxLength(4);

                entity.Property(e => e.TranDesc).HasMaxLength(50);

                entity.Property(e => e.TranDocNo)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.TranEvent).HasMaxLength(20);

                entity.Property(e => e.TranIndex2).HasMaxLength(15);

                entity.Property(e => e.TranMod).HasMaxLength(5);

                entity.Property(e => e.TranNature)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TranProd).HasMaxLength(10);

                entity.Property(e => e.TranProfit).HasMaxLength(10);

                entity.Property(e => e.TranRef).HasMaxLength(15);

                entity.Property(e => e.TranSale).HasMaxLength(10);

                entity.Property(e => e.TranSapAcc).HasMaxLength(19);

                entity.Property(e => e.TranStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TranTerm).HasMaxLength(10);

                entity.Property(e => e.VouchDate).HasColumnType("smalldatetime");

                entity.Property(e => e.VouchID)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<ViewMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewMaster");

                entity.Property(e => e.AcceptDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AcceptFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.BCnty).HasMaxLength(3);

                entity.Property(e => e.BName).HasMaxLength(175);

                entity.Property(e => e.BPOFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(20);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(20);

                entity.Property(e => e.CCS_LmType).HasMaxLength(3);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.Corr_BANK).HasMaxLength(20);

                entity.Property(e => e.Corr_Cnty)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Corr_Name)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CustCode).HasMaxLength(20);

                entity.Property(e => e.DNumber)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DocNo).HasMaxLength(20);

                entity.Property(e => e.DocNo1).HasMaxLength(35);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventMode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EventName).HasMaxLength(25);

                entity.Property(e => e.FacNo).HasMaxLength(15);

                entity.Property(e => e.FlagBack)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FlagDue)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ISS_BANK)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.IntFixDate).HasColumnType("smalldatetime");

                entity.Property(e => e.IntRateCode).HasMaxLength(10);

                entity.Property(e => e.KeyNumber).HasMaxLength(35);

                entity.Property(e => e.LastPayment).HasColumnType("datetime");

                entity.Property(e => e.Module).HasMaxLength(15);

                entity.Property(e => e.OverdueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PastDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PayMethod)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.PayType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RateFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RecStatus).HasMaxLength(10);

                entity.Property(e => e.Reference).HasMaxLength(35);

                entity.Property(e => e.Relation)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.SubProduct)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TenorTerm).HasMaxLength(50);

                entity.Property(e => e.TenorType).HasMaxLength(20);

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.WithOutFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.WithOutType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Wref_Bank_ID).HasMaxLength(14);

                entity.Property(e => e.collectrefund).HasMaxLength(25);
            });

            modelBuilder.Entity<ViewMasterClose>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewMasterClose");

                entity.Property(e => e.AcceptDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AcceptFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("datetime");

                entity.Property(e => e.BCnty).HasMaxLength(3);

                entity.Property(e => e.BName).HasMaxLength(175);

                entity.Property(e => e.BPOFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(20);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(20);

                entity.Property(e => e.CCS_LmType).HasMaxLength(3);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.Corr_BANK).HasMaxLength(20);

                entity.Property(e => e.Corr_Cnty)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Corr_Name)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CustCode).HasMaxLength(20);

                entity.Property(e => e.DNumber)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DocNo).HasMaxLength(20);

                entity.Property(e => e.DocNo1).HasMaxLength(35);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventMode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EventName).HasMaxLength(25);

                entity.Property(e => e.FacNo).HasMaxLength(15);

                entity.Property(e => e.FlagBack)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FlagDue)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ISS_BANK)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.IntFixDate).HasColumnType("smalldatetime");

                entity.Property(e => e.IntRateCode).HasMaxLength(10);

                entity.Property(e => e.KeyNumber).HasMaxLength(35);

                entity.Property(e => e.LastPayment).HasColumnType("datetime");

                entity.Property(e => e.Module).HasMaxLength(15);

                entity.Property(e => e.OverdueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PastDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PayMethod)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.PayType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RateFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RecStatus).HasMaxLength(10);

                entity.Property(e => e.Reference).HasMaxLength(35);

                entity.Property(e => e.SubProduct)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TenorTerm).HasMaxLength(50);

                entity.Property(e => e.TenorType).HasMaxLength(20);

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.WithOutFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.WithOutType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Wref_Bank_ID).HasMaxLength(14);

                entity.Property(e => e.collectrefund).HasMaxLength(25);
            });

            modelBuilder.Entity<ViewMasterDailyOut>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewMasterDailyOuts");

                entity.Property(e => e.CCy).HasMaxLength(3);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.FlagDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.GFBCInt).HasMaxLength(10);

                entity.Property(e => e.GFBCOuts).HasMaxLength(10);

                entity.Property(e => e.GFMSAccInt).HasMaxLength(11);

                entity.Property(e => e.GFMSAccOuts).HasMaxLength(11);

                entity.Property(e => e.GFMSBran).HasMaxLength(4);

                entity.Property(e => e.KeyNumber).HasMaxLength(15);

                entity.Property(e => e.LastEvent).HasMaxLength(25);

                entity.Property(e => e.LastPayment).HasColumnType("smalldatetime");

                entity.Property(e => e.LiabType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Module).HasMaxLength(5);

                entity.Property(e => e.OutsDate).HasMaxLength(10);

                entity.Property(e => e.OverdueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PastDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ProdCode).HasMaxLength(5);

                entity.Property(e => e.RCCode).HasMaxLength(5);

                entity.Property(e => e.RMCode).HasMaxLength(10);

                entity.Property(e => e.Reference).HasMaxLength(50);

                entity.Property(e => e.SBUCode).HasMaxLength(5);

                entity.Property(e => e.SubProduct).HasMaxLength(5);

                entity.Property(e => e.TENOR_TYPE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenorDay).HasMaxLength(4);

                entity.Property(e => e.TenorType).HasMaxLength(20);

                entity.Property(e => e.WithOutFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.WithOutType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ViewMasterGL>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewMasterGL");

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.BCnty).HasMaxLength(3);

                entity.Property(e => e.BName).HasMaxLength(175);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(20);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(20);

                entity.Property(e => e.CCS_LmType).HasMaxLength(3);

                entity.Property(e => e.CENTERID).HasMaxLength(4);

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.Corr_BANK).HasMaxLength(20);

                entity.Property(e => e.Corr_Cnty)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Corr_Name)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CustCode).HasMaxLength(20);

                entity.Property(e => e.DNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventName).HasMaxLength(30);

                entity.Property(e => e.Facno)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.FlagDue)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KeyNumber)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.RecStatus).HasMaxLength(10);

                entity.Property(e => e.Reference).HasMaxLength(35);

                entity.Property(e => e.TenorTerm).HasMaxLength(50);

                entity.Property(e => e.TenorType).HasMaxLength(20);

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.WithOutFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.WithOutType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Wref_Bank_ID).HasMaxLength(14);

                entity.Property(e => e.collectrefund).HasMaxLength(25);
            });

            modelBuilder.Entity<ViewMasterRecalLiab>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewMasterRecalLiab");

                entity.Property(e => e.AcceptDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AcceptFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.BCnty).HasMaxLength(3);

                entity.Property(e => e.BName).HasMaxLength(175);

                entity.Property(e => e.BPOFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(20);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(20);

                entity.Property(e => e.CCS_LmType).HasMaxLength(3);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.Corr_BANK).HasMaxLength(20);

                entity.Property(e => e.Corr_Cnty)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Corr_Name)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CustCode).HasMaxLength(20);

                entity.Property(e => e.DNumber)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DocNo).HasMaxLength(20);

                entity.Property(e => e.DocNo1).HasMaxLength(35);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventMode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EventName).HasMaxLength(25);

                entity.Property(e => e.FacNo).HasMaxLength(15);

                entity.Property(e => e.FlagBack)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FlagDue)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ISS_BANK)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.IntFixDate).HasColumnType("smalldatetime");

                entity.Property(e => e.IntRateCode).HasMaxLength(10);

                entity.Property(e => e.KeyNumber).HasMaxLength(35);

                entity.Property(e => e.LastPayment).HasColumnType("datetime");

                entity.Property(e => e.Module).HasMaxLength(15);

                entity.Property(e => e.OverdueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PastDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PayMethod)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.PayType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RateFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RecStatus).HasMaxLength(10);

                entity.Property(e => e.Reference).HasMaxLength(35);

                entity.Property(e => e.Relation)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.SubProduct)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TenorTerm).HasMaxLength(50);

                entity.Property(e => e.TenorType).HasMaxLength(20);

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.WithOutFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.WithOutType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Wref_Bank_ID).HasMaxLength(14);

                entity.Property(e => e.collectrefund).HasMaxLength(25);
            });

            modelBuilder.Entity<ViewMonInterest>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewMonInterest");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.DocCcy).HasMaxLength(3);

                entity.Property(e => e.DocCust).HasMaxLength(6);

                entity.Property(e => e.DocMonth)
                    .IsRequired()
                    .HasMaxLength(7);

                entity.Property(e => e.Login).HasMaxLength(4);

                entity.Property(e => e.SendFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ViewNostro>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewNostro");

                entity.Property(e => e.Bank_Cnty).HasMaxLength(2);

                entity.Property(e => e.Bank_Name).HasMaxLength(70);

                entity.Property(e => e.Nostro_Bank)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.Nostro_Ccy)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ViewODU>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewODU");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Cust_Code)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Facility_No)
                    .IsRequired()
                    .HasMaxLength(13);
            });

            modelBuilder.Entity<ViewPayInterest>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewPayInterest");

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventName).HasMaxLength(25);

                entity.Property(e => e.FlagDue)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KeyNumber).HasMaxLength(35);

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewPayment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewPayment");

                entity.Property(e => e.DpContract).HasMaxLength(20);

                entity.Property(e => e.DpFromDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DpPayName).HasMaxLength(80);

                entity.Property(e => e.DpRemark).HasMaxLength(200);

                entity.Property(e => e.DpToDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RpApplicant).HasMaxLength(70);

                entity.Property(e => e.RpChqBank).HasMaxLength(10);

                entity.Property(e => e.RpChqBranch).HasMaxLength(25);

                entity.Property(e => e.RpChqNo).HasMaxLength(15);

                entity.Property(e => e.RpCustAc1).HasMaxLength(15);

                entity.Property(e => e.RpCustAc2).HasMaxLength(15);

                entity.Property(e => e.RpCustAc3).HasMaxLength(15);

                entity.Property(e => e.RpCustCode).HasMaxLength(6);

                entity.Property(e => e.RpDocNo).HasMaxLength(15);

                entity.Property(e => e.RpEvent).HasMaxLength(20);

                entity.Property(e => e.RpIssBank).HasMaxLength(70);

                entity.Property(e => e.RpModule).HasMaxLength(5);

                entity.Property(e => e.RpNote).HasMaxLength(200);

                entity.Property(e => e.RpPayBy).HasMaxLength(15);

                entity.Property(e => e.RpPayDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RpPrint)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RpRecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RpReceiptNo).HasMaxLength(15);

                entity.Property(e => e.RpRefer1).HasMaxLength(70);

                entity.Property(e => e.RpRefer2).HasMaxLength(70);

                entity.Property(e => e.RpStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ViewPending>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewPending");

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.COLLECTION)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.CustCode).HasMaxLength(20);

                entity.Property(e => e.CustName).HasMaxLength(500);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventFlag)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.EventName).HasMaxLength(30);

                entity.Property(e => e.KeyNumber)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PayFlag).HasMaxLength(6);

                entity.Property(e => e.RecStatus).HasMaxLength(10);

                entity.Property(e => e.Reference).HasMaxLength(35);

                entity.Property(e => e.RpReceiptNo).HasMaxLength(15);

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.WithOutFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.WithOutType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Wref_Bank_ID)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.collectrefund).HasMaxLength(25);
            });

            modelBuilder.Entity<ViewQuoteRate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewQuoteRate");

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Keynumber).HasMaxLength(35);

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RegFunct)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Tenor)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<ViewRemTran>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewRemTrans");

                entity.Property(e => e.CustName).HasMaxLength(35);

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.KeyNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.RemType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ViewSubOutCust>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewSubOutCust");

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.Cust_Name).HasMaxLength(70);

                entity.Property(e => e.FacNo).HasMaxLength(15);

                entity.Property(e => e.FlagDue)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SubProduct)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewSumMonInt>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewSumMonInt");

                entity.Property(e => e.BatchType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CalDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.DebitACC).HasMaxLength(15);

                entity.Property(e => e.DocCust).HasMaxLength(6);

                entity.Property(e => e.DocMonth)
                    .IsRequired()
                    .HasMaxLength(7);

                entity.Property(e => e.Login).HasMaxLength(4);

                entity.Property(e => e.SendFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpReceipt).HasMaxLength(15);
            });

            modelBuilder.Entity<ViewTRnostro>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewTRnostro");

                entity.Property(e => e.Allocation).HasMaxLength(10);

                entity.Property(e => e.Amend)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.BCnty)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.BName).HasMaxLength(144);

                entity.Property(e => e.COLLECTION)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.Corr_BANK)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Corr_Cnty)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Corr_Name)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.CustName)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DNumber)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Decrease_Amt)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EventName).HasMaxLength(25);

                entity.Property(e => e.FlagDue)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ISS_BANK)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Increase_Amt)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KeyNumber)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.LastReceiptNo).HasMaxLength(15);

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PayFlag)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.TENOR_TYPE)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.collectrefund).HasMaxLength(25);
            });

            modelBuilder.Entity<ViewTmpBack>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewTmpBack");

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.Event).HasMaxLength(25);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PaymentDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RefNumber).HasMaxLength(15);

                entity.Property(e => e.TRNumber).HasMaxLength(35);

                entity.Property(e => e.centerid).HasMaxLength(4);

                entity.Property(e => e.custAddr).HasMaxLength(144);
            });

            modelBuilder.Entity<ViewTransCLB>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewTransCLB");

                entity.Property(e => e.Bank_Add2).HasMaxLength(35);

                entity.Property(e => e.Bank_Add3).HasMaxLength(35);

                entity.Property(e => e.Bank_Add4).HasMaxLength(35);

                entity.Property(e => e.Bank_Name).HasMaxLength(70);

                entity.Property(e => e.Bran_Code)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.Bran_Name).HasMaxLength(70);

                entity.Property(e => e.CICDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CLCCy).HasMaxLength(3);

                entity.Property(e => e.CLNumber).HasMaxLength(15);

                entity.Property(e => e.CollectBank).HasMaxLength(20);

                entity.Property(e => e.RecType).HasMaxLength(10);
            });

            modelBuilder.Entity<ViewVolumeCom>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewVolumeCom");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.CustCode).HasMaxLength(8);

                entity.Property(e => e.CustName).HasMaxLength(180);

                entity.Property(e => e.Keynumber).HasMaxLength(20);

                entity.Property(e => e.SendFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TRANEVENT).HasMaxLength(20);

                entity.Property(e => e.TranAccount).HasMaxLength(15);

                entity.Property(e => e.TranCcy).HasMaxLength(3);

                entity.Property(e => e.TranDept).HasMaxLength(4);

                entity.Property(e => e.TranDesc).HasMaxLength(50);

                entity.Property(e => e.TranMod).HasMaxLength(5);

                entity.Property(e => e.TranNature)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TranStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VouchDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<convEXBC>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("convEXBC");

                entity.Property(e => e.EXPORTLCNO).HasMaxLength(15);
            });

            modelBuilder.Entity<convEXLC>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("convEXLC");

                entity.Property(e => e.EXPORTLCNO).HasMaxLength(15);
            });

            modelBuilder.Entity<customer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("customer");

                entity.Property(e => e.AuthDate).HasColumnType("datetime");

                entity.Property(e => e.CLMS_Flag).HasMaxLength(255);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Cust_AcFlag1).HasMaxLength(255);

                entity.Property(e => e.Cust_AcFlag2).HasMaxLength(255);

                entity.Property(e => e.Cust_AcFlag3).HasMaxLength(255);

                entity.Property(e => e.Cust_AcFlag4).HasMaxLength(255);

                entity.Property(e => e.Cust_AcType1).HasMaxLength(255);

                entity.Property(e => e.Cust_AcType2).HasMaxLength(255);

                entity.Property(e => e.Cust_AcType3).HasMaxLength(255);

                entity.Property(e => e.Cust_AcType4).HasMaxLength(255);

                entity.Property(e => e.Cust_BOI).HasMaxLength(255);

                entity.Property(e => e.Cust_CommLC).HasMaxLength(255);

                entity.Property(e => e.Cust_EntDate).HasColumnType("datetime");

                entity.Property(e => e.Cust_Group).HasMaxLength(255);

                entity.Property(e => e.Cust_RegistDate).HasColumnType("datetime");

                entity.Property(e => e.Cust_Size).HasMaxLength(255);

                entity.Property(e => e.Cust_Status).HasMaxLength(255);

                entity.Property(e => e.Cust_Type).HasMaxLength(255);

                entity.Property(e => e.DMS).HasMaxLength(255);

                entity.Property(e => e.IRateFlag).HasMaxLength(255);

                entity.Property(e => e.Online_Flag).HasMaxLength(255);

                entity.Property(e => e.RecStatus).HasMaxLength(255);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<fm314wc03>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("fm314wc03");

                entity.Property(e => e.F1).HasMaxLength(255);

                entity.Property(e => e.F10).HasMaxLength(255);

                entity.Property(e => e.F11).HasMaxLength(255);

                entity.Property(e => e.F12).HasMaxLength(255);

                entity.Property(e => e.F13).HasMaxLength(255);

                entity.Property(e => e.F14).HasMaxLength(255);

                entity.Property(e => e.F15).HasMaxLength(255);

                entity.Property(e => e.F18).HasMaxLength(255);

                entity.Property(e => e.F19).HasMaxLength(255);

                entity.Property(e => e.F2).HasMaxLength(255);

                entity.Property(e => e.F20).HasMaxLength(255);

                entity.Property(e => e.F23).HasMaxLength(255);

                entity.Property(e => e.F3).HasMaxLength(255);

                entity.Property(e => e.F37).HasMaxLength(255);

                entity.Property(e => e.F42).HasMaxLength(255);

                entity.Property(e => e.F49).HasMaxLength(255);

                entity.Property(e => e.F50).HasMaxLength(255);

                entity.Property(e => e.F8).HasMaxLength(255);

                entity.Property(e => e.F9).HasMaxLength(255);
            });

            modelBuilder.Entity<fm315wl01>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("fm315wl01");

                entity.Property(e => e.F1).HasMaxLength(255);

                entity.Property(e => e.F10).HasMaxLength(255);

                entity.Property(e => e.F11).HasMaxLength(255);

                entity.Property(e => e.F12).HasMaxLength(255);

                entity.Property(e => e.F13).HasMaxLength(255);

                entity.Property(e => e.F14).HasMaxLength(255);

                entity.Property(e => e.F15).HasMaxLength(255);

                entity.Property(e => e.F16).HasMaxLength(255);

                entity.Property(e => e.F17).HasMaxLength(255);

                entity.Property(e => e.F18).HasMaxLength(255);

                entity.Property(e => e.F2).HasMaxLength(255);

                entity.Property(e => e.F24).HasMaxLength(255);

                entity.Property(e => e.F3).HasMaxLength(255);

                entity.Property(e => e.F8).HasMaxLength(255);

                entity.Property(e => e.F9).HasMaxLength(255);
            });

            modelBuilder.Entity<holiday>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("holiday");

                entity.Property(e => e.AuthCode).HasMaxLength(255);

                entity.Property(e => e.AuthDate).HasMaxLength(255);

                entity.Property(e => e.Hol_Date).HasMaxLength(255);

                entity.Property(e => e.Hol_Desc).HasMaxLength(255);

                entity.Property(e => e.Hol_RecStat).HasMaxLength(255);

                entity.Property(e => e.Hol_Year).HasMaxLength(255);

                entity.Property(e => e.UpdateDate).HasMaxLength(255);

                entity.Property(e => e.UserCode).HasMaxLength(255);
            });

            modelBuilder.Entity<mAOCode>(entity =>
            {
                entity.HasKey(e => e.ao_code);

                entity.ToTable("mAOCode");

                entity.Property(e => e.ao_code).HasMaxLength(5);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.ao_name).HasMaxLength(70);

                entity.Property(e => e.ao_rccode).HasMaxLength(70);
            });

            modelBuilder.Entity<mAPPError>(entity =>
            {
                entity.HasKey(e => e.ErrCode)
                    .HasName("PK_mF1Error");

                entity.ToTable("mAPPError");

                entity.Property(e => e.ErrCode).HasMaxLength(4);

                entity.Property(e => e.ErrDesc).HasMaxLength(100);
            });

            modelBuilder.Entity<mAccount>(entity =>
            {
                entity.HasKey(e => e.Acc_Code)
                    .HasName("pk_acc_code");

                entity.ToTable("mAccount");

                entity.Property(e => e.Acc_Code).HasMaxLength(19);

                entity.Property(e => e.Acc_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Acc_GFMS).HasMaxLength(15);

                entity.Property(e => e.Acc_GFMS_Sub).HasMaxLength(15);

                entity.Property(e => e.Acc_Map).HasMaxLength(15);

                entity.Property(e => e.Acc_Name).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.GFMS_Bran).HasMaxLength(15);

                entity.Property(e => e.GFMS_Map).HasMaxLength(15);

                entity.Property(e => e.GFMS_Prod).HasMaxLength(5);

                entity.Property(e => e.GFMS_SBU).HasMaxLength(15);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mAccount1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mAccount1");

                entity.Property(e => e.Acc_Code).HasMaxLength(255);

                entity.Property(e => e.Acc_GFMS).HasMaxLength(255);

                entity.Property(e => e.Acc_GFMS_Sub).HasMaxLength(255);

                entity.Property(e => e.Acc_Map).HasMaxLength(255);

                entity.Property(e => e.Acc_Name).HasMaxLength(255);

                entity.Property(e => e.CreateDate).HasMaxLength(255);

                entity.Property(e => e.GFMS_Bran).HasMaxLength(255);

                entity.Property(e => e.GFMS_Map).HasMaxLength(255);

                entity.Property(e => e.GFMS_Prod).HasMaxLength(255);

                entity.Property(e => e.GFMS_SBU).HasMaxLength(255);

                entity.Property(e => e.UpdateDate).HasMaxLength(255);

                entity.Property(e => e.UserCode).HasMaxLength(255);
            });

            modelBuilder.Entity<mAuth>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mAuth");

                entity.Property(e => e.ModCode)
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.ModLevel)
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.UserID).HasMaxLength(12);
            });

            modelBuilder.Entity<mBankFile>(entity =>
            {
                entity.HasKey(e => e.Bank_Code);

                entity.ToTable("mBankFile");

                entity.Property(e => e.Bank_Code).HasMaxLength(14);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("datetime");

                entity.Property(e => e.Bank_AcCcy1)
                    .HasMaxLength(3)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Bank_AcCcy2).HasMaxLength(3);

                entity.Property(e => e.Bank_AcCcy3).HasMaxLength(3);

                entity.Property(e => e.Bank_AcCode1).HasMaxLength(15);

                entity.Property(e => e.Bank_AcCode2).HasMaxLength(15);

                entity.Property(e => e.Bank_AcCode3).HasMaxLength(15);

                entity.Property(e => e.Bank_AcName1).HasMaxLength(70);

                entity.Property(e => e.Bank_AcName2).HasMaxLength(70);

                entity.Property(e => e.Bank_AcName3).HasMaxLength(70);

                entity.Property(e => e.Bank_Add1).HasMaxLength(35);

                entity.Property(e => e.Bank_Add2).HasMaxLength(35);

                entity.Property(e => e.Bank_Add3).HasMaxLength(35);

                entity.Property(e => e.Bank_Add4).HasMaxLength(35);

                entity.Property(e => e.Bank_AddSw1).HasMaxLength(35);

                entity.Property(e => e.Bank_AddSw2).HasMaxLength(35);

                entity.Property(e => e.Bank_AddSw3).HasMaxLength(35);

                entity.Property(e => e.Bank_AddSw4).HasMaxLength(35);

                entity.Property(e => e.Bank_AddSw5).HasMaxLength(35);

                entity.Property(e => e.Bank_AddSw6).HasMaxLength(35);

                entity.Property(e => e.Bank_AddSw7).HasMaxLength(35);

                entity.Property(e => e.Bank_Authen)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Bank_Ccy).HasMaxLength(3);

                entity.Property(e => e.Bank_City).HasMaxLength(20);

                entity.Property(e => e.Bank_Cnty).HasMaxLength(2);

                entity.Property(e => e.Bank_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Bank_LimitAmt1).HasDefaultValueSql("((0))");

                entity.Property(e => e.Bank_LimitCcy1).HasMaxLength(3);

                entity.Property(e => e.Bank_LimitCcy2).HasMaxLength(3);

                entity.Property(e => e.Bank_LimitCcy3).HasMaxLength(3);

                entity.Property(e => e.Bank_LimitCode1).HasMaxLength(10);

                entity.Property(e => e.Bank_LimitCode2).HasMaxLength(10);

                entity.Property(e => e.Bank_LimitCode3)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Bank_Name).HasMaxLength(70);

                entity.Property(e => e.Bank_Nego).HasDefaultValueSql("((0))");

                entity.Property(e => e.Bank_Nostro1).HasMaxLength(19);

                entity.Property(e => e.Bank_Nostro2).HasMaxLength(19);

                entity.Property(e => e.Bank_Nostro3).HasMaxLength(19);

                entity.Property(e => e.Bank_Outsource).HasDefaultValueSql("((0))");

                entity.Property(e => e.Bank_Rating).HasMaxLength(4);

                entity.Property(e => e.Bank_Rebate).HasDefaultValueSql("((0))");

                entity.Property(e => e.Bank_Reissue).HasDefaultValueSql("((0))");

                entity.Property(e => e.Bank_Relay).HasDefaultValueSql("((0))");

                entity.Property(e => e.Bank_Remark).HasMaxLength(250);

                entity.Property(e => e.Bank_Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Bank_Swift).HasMaxLength(14);

                entity.Property(e => e.Bank_Zip).HasMaxLength(10);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mBranch>(entity =>
            {
                entity.HasKey(e => e.Bran_Code);

                entity.ToTable("mBranch");

                entity.Property(e => e.Bran_Code).HasMaxLength(4);

                entity.Property(e => e.Bran_BA).HasMaxLength(4);

                entity.Property(e => e.Bran_Cost).HasMaxLength(15);

                entity.Property(e => e.Bran_GL).HasMaxLength(8);

                entity.Property(e => e.Bran_Name).HasMaxLength(70);

                entity.Property(e => e.Bran_Profit).HasMaxLength(15);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.OnePUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Prov_Code).HasMaxLength(5);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mBuArea>(entity =>
            {
                entity.HasKey(e => e.BA_Code);

                entity.ToTable("mBuArea");

                entity.Property(e => e.BA_Code).HasMaxLength(4);

                entity.Property(e => e.BA_Cost).HasMaxLength(20);

                entity.Property(e => e.BA_Desc).HasMaxLength(50);

                entity.Property(e => e.BA_Profit).HasMaxLength(20);
            });

            modelBuilder.Entity<mBusType>(entity =>
            {
                entity.HasKey(e => e.BuType_Code);

                entity.ToTable("mBusType");

                entity.Property(e => e.BuType_Code).HasMaxLength(7);

                entity.Property(e => e.BuType_Name).HasMaxLength(70);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mCampaign>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mCampaign");

                entity.Property(e => e.Campaign_Code)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Campaign_Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Campaign_Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<mControl>(entity =>
            {
                entity.HasKey(e => new { e.CTL_Type, e.CTL_Code, e.CTL_ID });

                entity.ToTable("mControl");

                entity.Property(e => e.CTL_Type).HasMaxLength(10);

                entity.Property(e => e.CTL_Code).HasMaxLength(20);

                entity.Property(e => e.CTL_ID).HasMaxLength(50);

                entity.Property(e => e.CTL_Desc).HasMaxLength(200);

                entity.Property(e => e.CTL_Name).HasMaxLength(50);

                entity.Property(e => e.CTL_Note1).HasMaxLength(50);

                entity.Property(e => e.CTL_Note2).HasMaxLength(50);
            });

            modelBuilder.Entity<mControlBatch>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mControlBatch");

                entity.Property(e => e.BatchDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ContFlag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<mControlDate>(entity =>
            {
                entity.HasKey(e => e.ContDate);

                entity.ToTable("mControlDate");

                entity.Property(e => e.ContDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ContFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ContNextDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdUser).HasMaxLength(12);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mCountry>(entity =>
            {
                entity.HasKey(e => e.Cnty_Code);

                entity.ToTable("mCountry");

                entity.Property(e => e.Cnty_Code).HasMaxLength(2);

                entity.Property(e => e.Cnty_Area).HasMaxLength(2);

                entity.Property(e => e.Cnty_Name).HasMaxLength(35);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mCurrency>(entity =>
            {
                entity.HasKey(e => e.Ccy_Code);

                entity.ToTable("mCurrency");

                entity.Property(e => e.Ccy_Code).HasMaxLength(3);

                entity.Property(e => e.Ccy_GE).HasMaxLength(3);

                entity.Property(e => e.Ccy_GEC).HasMaxLength(3);

                entity.Property(e => e.Ccy_Name).HasMaxLength(35);

                entity.Property(e => e.Ccy_SWDEC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mCustRate>(entity =>
            {
                entity.HasKey(e => new { e.Def_Cust, e.Def_Mod, e.Def_Exp })
                    .HasName("PK_mStandard");

                entity.ToTable("mCustRate");

                entity.Property(e => e.Def_Cust).HasMaxLength(6);

                entity.Property(e => e.Def_Mod).HasMaxLength(5);

                entity.Property(e => e.Def_Exp).HasMaxLength(10);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Def_Base).HasDefaultValueSql("((0))");

                entity.Property(e => e.Def_Max).HasDefaultValueSql("((0))");

                entity.Property(e => e.Def_Min).HasDefaultValueSql("((0))");

                entity.Property(e => e.Def_Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mCustTFL>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mCustTFL");

                entity.Property(e => e.AuthCode).HasMaxLength(8);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Cust_AcBran1).HasMaxLength(4);

                entity.Property(e => e.Cust_AcBran2).HasMaxLength(4);

                entity.Property(e => e.Cust_AcBran3).HasMaxLength(4);

                entity.Property(e => e.Cust_AcBran4).HasMaxLength(4);

                entity.Property(e => e.Cust_AcCcy1).HasMaxLength(3);

                entity.Property(e => e.Cust_AcCcy2).HasMaxLength(3);

                entity.Property(e => e.Cust_AcCcy3).HasMaxLength(3);

                entity.Property(e => e.Cust_AcCcy4).HasMaxLength(3);

                entity.Property(e => e.Cust_AcFlag1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_AcFlag2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_AcFlag3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_AcFlag4)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_AcName1).HasMaxLength(50);

                entity.Property(e => e.Cust_AcName2).HasMaxLength(50);

                entity.Property(e => e.Cust_AcName3).HasMaxLength(50);

                entity.Property(e => e.Cust_AcName4).HasMaxLength(50);

                entity.Property(e => e.Cust_AcNo1).HasMaxLength(15);

                entity.Property(e => e.Cust_AcNo2).HasMaxLength(15);

                entity.Property(e => e.Cust_AcNo3).HasMaxLength(15);

                entity.Property(e => e.Cust_AcNo4).HasMaxLength(15);

                entity.Property(e => e.Cust_AcType1)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_AcType2)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_AcType3)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_AcType4)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_Add1_Cnty).HasMaxLength(2);

                entity.Property(e => e.Cust_Add1_Email).HasMaxLength(35);

                entity.Property(e => e.Cust_Add1_Faxno).HasMaxLength(20);

                entity.Property(e => e.Cust_Add1_Line1).HasMaxLength(35);

                entity.Property(e => e.Cust_Add1_Line2).HasMaxLength(35);

                entity.Property(e => e.Cust_Add1_Line3).HasMaxLength(35);

                entity.Property(e => e.Cust_Add1_Line4).HasMaxLength(35);

                entity.Property(e => e.Cust_Add1_Prov).HasMaxLength(5);

                entity.Property(e => e.Cust_Add1_Telno).HasMaxLength(20);

                entity.Property(e => e.Cust_Add2_Cnty).HasMaxLength(2);

                entity.Property(e => e.Cust_Add2_Faxno).HasMaxLength(20);

                entity.Property(e => e.Cust_Add2_Line1).HasMaxLength(35);

                entity.Property(e => e.Cust_Add2_Line2).HasMaxLength(35);

                entity.Property(e => e.Cust_Add2_Line3).HasMaxLength(35);

                entity.Property(e => e.Cust_Add2_Line4).HasMaxLength(35);

                entity.Property(e => e.Cust_Add2_Telno).HasMaxLength(20);

                entity.Property(e => e.Cust_Add2_prov).HasMaxLength(5);

                entity.Property(e => e.Cust_Ao).HasMaxLength(5);

                entity.Property(e => e.Cust_BOI)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_Bran).HasMaxLength(3);

                entity.Property(e => e.Cust_BuType).HasMaxLength(7);

                entity.Property(e => e.Cust_CCID).HasMaxLength(8);

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.Cust_CommLC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_Contact).HasMaxLength(50);

                entity.Property(e => e.Cust_CsType).HasMaxLength(6);

                entity.Property(e => e.Cust_EntDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Cust_Group)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_LastName).HasMaxLength(70);

                entity.Property(e => e.Cust_Lo).HasMaxLength(5);

                entity.Property(e => e.Cust_Name).HasMaxLength(70);

                entity.Property(e => e.Cust_Nation).HasMaxLength(2);

                entity.Property(e => e.Cust_Parent).HasMaxLength(6);

                entity.Property(e => e.Cust_Rating).HasMaxLength(4);

                entity.Property(e => e.Cust_RegistDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Cust_RegistID).HasMaxLength(13);

                entity.Property(e => e.Cust_Remark).HasMaxLength(200);

                entity.Property(e => e.Cust_Size)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_T24).HasMaxLength(8);

                entity.Property(e => e.Cust_TLastName).HasMaxLength(70);

                entity.Property(e => e.Cust_TName).HasMaxLength(70);

                entity.Property(e => e.Cust_TTitle).HasMaxLength(3);

                entity.Property(e => e.Cust_TaxID).HasMaxLength(13);

                entity.Property(e => e.Cust_Title).HasMaxLength(3);

                entity.Property(e => e.Cust_Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DMS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IRateCcy).HasMaxLength(10);

                entity.Property(e => e.IRateFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IRateTHB).HasMaxLength(10);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.cust_acrelation1).HasMaxLength(6);

                entity.Property(e => e.cust_acrelation2).HasMaxLength(6);

                entity.Property(e => e.cust_acrelation3).HasMaxLength(6);

                entity.Property(e => e.cust_acrelation4).HasMaxLength(6);
            });

            modelBuilder.Entity<mCustType>(entity =>
            {
                entity.HasKey(e => e.CsType_Code);

                entity.ToTable("mCustType");

                entity.Property(e => e.CsType_Code).HasMaxLength(6);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CsType_Name).HasMaxLength(70);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mCustomer>(entity =>
            {
                entity.HasKey(e => e.Cust_Code);

                entity.ToTable("mCustomer");

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CCS_REF).HasMaxLength(14);

                entity.Property(e => e.CLMS_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CNUM).HasMaxLength(9);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Cust_AcBran1).HasMaxLength(4);

                entity.Property(e => e.Cust_AcBran2).HasMaxLength(4);

                entity.Property(e => e.Cust_AcBran3).HasMaxLength(4);

                entity.Property(e => e.Cust_AcBran4).HasMaxLength(4);

                entity.Property(e => e.Cust_AcCcy1).HasMaxLength(3);

                entity.Property(e => e.Cust_AcCcy2).HasMaxLength(3);

                entity.Property(e => e.Cust_AcCcy3).HasMaxLength(3);

                entity.Property(e => e.Cust_AcCcy4).HasMaxLength(3);

                entity.Property(e => e.Cust_AcFlag1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_AcFlag2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_AcFlag3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_AcFlag4)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_AcName1).HasMaxLength(50);

                entity.Property(e => e.Cust_AcName2).HasMaxLength(50);

                entity.Property(e => e.Cust_AcName3).HasMaxLength(50);

                entity.Property(e => e.Cust_AcName4).HasMaxLength(50);

                entity.Property(e => e.Cust_AcNo1).HasMaxLength(15);

                entity.Property(e => e.Cust_AcNo2).HasMaxLength(15);

                entity.Property(e => e.Cust_AcNo3).HasMaxLength(15);

                entity.Property(e => e.Cust_AcNo4).HasMaxLength(15);

                entity.Property(e => e.Cust_AcType1)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_AcType2)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_AcType3)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_AcType4)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_Add1_Cnty).HasMaxLength(2);

                entity.Property(e => e.Cust_Add1_Email).HasMaxLength(300);

                entity.Property(e => e.Cust_Add1_Faxno).HasMaxLength(20);

                entity.Property(e => e.Cust_Add1_Line1).HasMaxLength(35);

                entity.Property(e => e.Cust_Add1_Line2).HasMaxLength(35);

                entity.Property(e => e.Cust_Add1_Line3).HasMaxLength(35);

                entity.Property(e => e.Cust_Add1_Line4).HasMaxLength(35);

                entity.Property(e => e.Cust_Add1_Prov).HasMaxLength(5);

                entity.Property(e => e.Cust_Add1_Telno).HasMaxLength(20);

                entity.Property(e => e.Cust_Add2_Cnty).HasMaxLength(2);

                entity.Property(e => e.Cust_Add2_Faxno).HasMaxLength(20);

                entity.Property(e => e.Cust_Add2_Line1).HasMaxLength(35);

                entity.Property(e => e.Cust_Add2_Line2).HasMaxLength(35);

                entity.Property(e => e.Cust_Add2_Line3).HasMaxLength(35);

                entity.Property(e => e.Cust_Add2_Line4).HasMaxLength(35);

                entity.Property(e => e.Cust_Add2_Telno).HasMaxLength(20);

                entity.Property(e => e.Cust_Add2_prov).HasMaxLength(5);

                entity.Property(e => e.Cust_Ao).HasMaxLength(5);

                entity.Property(e => e.Cust_BOI)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_Bran).HasMaxLength(4);

                entity.Property(e => e.Cust_BuType).HasMaxLength(7);

                entity.Property(e => e.Cust_CCEmail).HasMaxLength(300);

                entity.Property(e => e.Cust_CCID).HasMaxLength(9);

                entity.Property(e => e.Cust_CIF).HasMaxLength(20);

                entity.Property(e => e.Cust_CommLC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_Contact).HasMaxLength(50);

                entity.Property(e => e.Cust_CsType).HasMaxLength(6);

                entity.Property(e => e.Cust_EntDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Cust_FilePassword).HasMaxLength(100);

                entity.Property(e => e.Cust_GFMSSBUCode).HasMaxLength(4);

                entity.Property(e => e.Cust_Group)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_LastName).HasMaxLength(70);

                entity.Property(e => e.Cust_Lo).HasMaxLength(8);

                entity.Property(e => e.Cust_Name).HasMaxLength(70);

                entity.Property(e => e.Cust_Nation).HasMaxLength(2);

                entity.Property(e => e.Cust_Parent).HasMaxLength(6);

                entity.Property(e => e.Cust_RCCode).HasMaxLength(5);

                entity.Property(e => e.Cust_RMCode).HasMaxLength(10);

                entity.Property(e => e.Cust_Rating).HasMaxLength(4);

                entity.Property(e => e.Cust_RegistDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Cust_RegistID).HasMaxLength(13);

                entity.Property(e => e.Cust_Remark).HasMaxLength(200);

                entity.Property(e => e.Cust_SBU).HasMaxLength(4);

                entity.Property(e => e.Cust_Size)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_T24).HasMaxLength(8);

                entity.Property(e => e.Cust_TLastName).HasMaxLength(70);

                entity.Property(e => e.Cust_TName).HasMaxLength(70);

                entity.Property(e => e.Cust_TTitle).HasMaxLength(3);

                entity.Property(e => e.Cust_TaxID).HasMaxLength(13);

                entity.Property(e => e.Cust_Title).HasMaxLength(3);

                entity.Property(e => e.Cust_Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DMS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IRateCcy).HasMaxLength(10);

                entity.Property(e => e.IRateFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IRateTHB).HasMaxLength(10);

                entity.Property(e => e.Online_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.cust_AcRelation4).HasMaxLength(6);

                entity.Property(e => e.cust_acrelation1).HasMaxLength(6);

                entity.Property(e => e.cust_acrelation2).HasMaxLength(6);

                entity.Property(e => e.cust_acrelation3).HasMaxLength(6);
            });

            modelBuilder.Entity<mDSPError>(entity =>
            {
                entity.HasKey(e => e.ErrCode);

                entity.ToTable("mDSPError");

                entity.Property(e => e.ErrCode).HasMaxLength(8);

                entity.Property(e => e.ErrDesc).HasMaxLength(100);
            });

            modelBuilder.Entity<mFcdAccount>(entity =>
            {
                entity.HasKey(e => e.FcdAccNo);

                entity.ToTable("mFcdAccount");

                entity.Property(e => e.FcdAccNo).HasMaxLength(13);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CheckLiab)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.CustName).HasMaxLength(100);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FcdAccBran).HasMaxLength(3);

                entity.Property(e => e.FcdAccName).HasMaxLength(70);

                entity.Property(e => e.FcdAccType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FcdCcy).HasMaxLength(3);

                entity.Property(e => e.FcdCcyName).HasMaxLength(50);

                entity.Property(e => e.FcdDeposit)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FcdFinInst)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FcdFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FcdResType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FcdSavFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FcdStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FlagRate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FromDate).HasColumnType("smalldatetime");

                entity.Property(e => e.HoldFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastmoveDate).HasColumnType("smalldatetime");

                entity.Property(e => e.OpenDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RefAccount).HasMaxLength(20);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.ToDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mFcdRate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mFcdRate");

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("datetime");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateTime)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Exch_Ccy)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mGood>(entity =>
            {
                entity.HasKey(e => e.Goods_Code);

                entity.Property(e => e.Goods_Code).HasMaxLength(4);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Goods_Desc).HasMaxLength(70);

                entity.Property(e => e.Goods_Purpose).HasMaxLength(6);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mInRateCode>(entity =>
            {
                entity.HasKey(e => e.InRate_Code);

                entity.ToTable("mInRateCode");

                entity.Property(e => e.InRate_Code).HasMaxLength(10);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.InRate_CcyFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.InRate_Name).HasMaxLength(35);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mLimitCode>(entity =>
            {
                entity.HasKey(e => e.Limit_Code);

                entity.ToTable("mLimitCode");

                entity.Property(e => e.Limit_Code).HasMaxLength(10);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Limit_DLC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_EXBC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_EXLC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_EXP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_EXPC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_IMEX)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_IMLC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_IMP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_IMTR)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_LG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_Name).HasMaxLength(35);

                entity.Property(e => e.Limit_UseCcy)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Limit_UseFor)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mLoCode>(entity =>
            {
                entity.HasKey(e => e.Lo_code);

                entity.ToTable("mLoCode");

                entity.Property(e => e.Lo_code).HasMaxLength(8);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Lo_Name).HasMaxLength(50);

                entity.Property(e => e.Lo_RcCode).HasMaxLength(35);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mMap1PCIF>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mMap1PCIF");
            });

            modelBuilder.Entity<mMap1PLimit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mMap1PLimit");
            });

            modelBuilder.Entity<mMapAOBR>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mMapAOBR");
            });

            modelBuilder.Entity<mMapAccount>(entity =>
            {
                entity.HasKey(e => e.mAcc_Code);

                entity.ToTable("mMapAccount");

                entity.Property(e => e.mAcc_Code).HasMaxLength(19);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.GFMS_Acc).HasMaxLength(50);

                entity.Property(e => e.GFMS_Bran).HasMaxLength(4);

                entity.Property(e => e.GFMS_Map).HasMaxLength(15);

                entity.Property(e => e.GFMS_Prod).HasMaxLength(5);

                entity.Property(e => e.GFMS_SBU).HasMaxLength(4);

                entity.Property(e => e.GFMS_SubAcc).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.mAcc_BsLine).HasMaxLength(10);

                entity.Property(e => e.mAcc_BuArea).HasMaxLength(4);

                entity.Property(e => e.mAcc_Cond).HasMaxLength(1);

                entity.Property(e => e.mAcc_Cost).HasMaxLength(10);

                entity.Property(e => e.mAcc_Mod).HasMaxLength(5);

                entity.Property(e => e.mAcc_Name).HasMaxLength(100);

                entity.Property(e => e.mAcc_New).HasMaxLength(19);

                entity.Property(e => e.mAcc_Profit).HasMaxLength(10);

                entity.Property(e => e.mAcc_Type).HasMaxLength(15);
            });

            modelBuilder.Entity<mMapBalanceCD>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mMapBalanceCD");

                entity.Property(e => e.CreateDate).HasMaxLength(8);

                entity.Property(e => e.GFMSAcc).HasMaxLength(7);

                entity.Property(e => e.GFMSMap).HasMaxLength(11);

                entity.Property(e => e.GFMSSub).HasMaxLength(4);

                entity.Property(e => e.IntsBLCode).HasMaxLength(10);

                entity.Property(e => e.Login).HasMaxLength(5);

                entity.Property(e => e.OutsBLCode).HasMaxLength(10);

                entity.Property(e => e.ProdCCy).HasMaxLength(5);

                entity.Property(e => e.ProdTHB).HasMaxLength(5);

                entity.Property(e => e.RStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RefNo).HasMaxLength(5);
            });

            modelBuilder.Entity<mMapFacNo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mMapFacNo");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<mMapProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mMapProduct");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.mProd_Code).HasMaxLength(10);

                entity.Property(e => e.mProd_Cond)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.mProd_Event)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.mProd_EventNm)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.mProd_Mod)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<mMapProductGFM>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mMapProductGFMS");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<mMapSWIFT>(entity =>
            {
                entity.HasKey(e => new { e.MTType, e.FDNumber });

                entity.ToTable("mMapSWIFT");

                entity.Property(e => e.MTType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FDNumber).HasMaxLength(5);

                entity.Property(e => e.FDName).HasMaxLength(100);
            });

            modelBuilder.Entity<mMapSaleUnit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mMapSaleUnit");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.mLo_BuArea).HasMaxLength(4);

                entity.Property(e => e.mLo_Code)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.mLo_Cost).HasMaxLength(10);

                entity.Property(e => e.mLo_Profit).HasMaxLength(10);

                entity.Property(e => e.mLo_SaleDesc).HasMaxLength(50);

                entity.Property(e => e.mLo_SaleUnit).HasMaxLength(8);
            });

            modelBuilder.Entity<mNostroGL>(entity =>
            {
                entity.HasKey(e => new { e.Nostro_Bank, e.Nostro_Ccy });

                entity.ToTable("mNostroGL");

                entity.Property(e => e.Nostro_Bank).HasMaxLength(14);

                entity.Property(e => e.Nostro_Ccy).HasMaxLength(3);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Nostro_GL).HasMaxLength(19);

                entity.Property(e => e.PayNote)
                    .HasMaxLength(700)
                    .IsUnicode(false);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mPlanComm>(entity =>
            {
                entity.HasKey(e => new { e.ComType, e.ComSeq })
                    .HasName("PK_mCommPlan");

                entity.ToTable("mPlanComm");

                entity.Property(e => e.ComType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ComMax).HasDefaultValueSql("((0))");

                entity.Property(e => e.ComMin).HasDefaultValueSql("((0))");

                entity.Property(e => e.ComRate).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<mProvince>(entity =>
            {
                entity.HasKey(e => e.Prov_Code);

                entity.ToTable("mProvince");

                entity.Property(e => e.Prov_Code).HasMaxLength(5);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Prov_Name).HasMaxLength(35);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mPurpose>(entity =>
            {
                entity.HasKey(e => e.Pur_Code);

                entity.ToTable("mPurpose");

                entity.Property(e => e.Pur_Code).HasMaxLength(6);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Pur_Desc).HasMaxLength(200);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mRelation>(entity =>
            {
                entity.HasKey(e => e.Rel_Code);

                entity.ToTable("mRelation");

                entity.Property(e => e.Rel_Code).HasMaxLength(6);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Rel_Desc).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mRunning>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mRunning");

                entity.Property(e => e.cust_run)
                    .HasColumnType("numeric(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.cust_show)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<mSetGenGL>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mSetGenGL");

                entity.Property(e => e.ACcy).HasMaxLength(255);

                entity.Property(e => e.ACenter).HasMaxLength(255);

                entity.Property(e => e.ACond).HasMaxLength(255);

                entity.Property(e => e.AEvent).HasMaxLength(255);

                entity.Property(e => e.AFlag).HasMaxLength(255);

                entity.Property(e => e.AModule).HasMaxLength(255);

                entity.Property(e => e.AName).HasMaxLength(255);

                entity.Property(e => e.ANature).HasMaxLength(255);

                entity.Property(e => e.ANote).HasMaxLength(255);

                entity.Property(e => e.ASeq).HasMaxLength(255);

                entity.Property(e => e.Accode).HasMaxLength(255);
            });

            modelBuilder.Entity<mSetGenGL2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mSetGenGL2");

                entity.Property(e => e.ACcy).HasMaxLength(255);

                entity.Property(e => e.ACenter).HasMaxLength(255);

                entity.Property(e => e.ACond).HasMaxLength(255);

                entity.Property(e => e.AEvent).HasMaxLength(255);

                entity.Property(e => e.AFlag).HasMaxLength(255);

                entity.Property(e => e.AModule).HasMaxLength(255);

                entity.Property(e => e.AName).HasMaxLength(255);

                entity.Property(e => e.ANature).HasMaxLength(255);

                entity.Property(e => e.ANote).HasMaxLength(255);

                entity.Property(e => e.ASeq).HasMaxLength(255);

                entity.Property(e => e.Accode).HasMaxLength(255);
            });

            modelBuilder.Entity<mSetGenGL3>(entity =>
            {
                entity.HasKey(e => new { e.AModule, e.AEvent, e.ASeq });

                entity.ToTable("mSetGenGL3");

                entity.Property(e => e.AModule).HasMaxLength(4);

                entity.Property(e => e.AEvent).HasMaxLength(20);

                entity.Property(e => e.ACcy).HasMaxLength(255);

                entity.Property(e => e.ACenter).HasMaxLength(255);

                entity.Property(e => e.ACond).HasMaxLength(255);

                entity.Property(e => e.AFlag).HasMaxLength(255);

                entity.Property(e => e.AName).HasMaxLength(255);

                entity.Property(e => e.ANature).HasMaxLength(255);

                entity.Property(e => e.ANote).HasMaxLength(255);

                entity.Property(e => e.Accode).HasMaxLength(255);
            });

            modelBuilder.Entity<mSetGenGLbk>(entity =>
            {
                entity.HasKey(e => new { e.AModule, e.AEvent, e.ASeq })
                    .HasName("PK_mSetGenGL");

                entity.ToTable("mSetGenGLbk");

                entity.Property(e => e.AModule).HasMaxLength(4);

                entity.Property(e => e.AEvent).HasMaxLength(20);

                entity.Property(e => e.ACcy)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ACenter).HasMaxLength(4);

                entity.Property(e => e.ACond).HasMaxLength(25);

                entity.Property(e => e.AFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AName).HasMaxLength(20);

                entity.Property(e => e.ANature)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ANote).HasMaxLength(25);

                entity.Property(e => e.Accode).HasMaxLength(14);
            });

            modelBuilder.Entity<mSetRate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mSetRate");

                entity.Property(e => e.MODULE)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RATEID)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<mTextFile>(entity =>
            {
                entity.HasKey(e => new { e.TextModule, e.TextField, e.TextNo });

                entity.ToTable("mTextFile");

                entity.Property(e => e.TextModule).HasMaxLength(5);

                entity.Property(e => e.TextField).HasMaxLength(20);

                entity.Property(e => e.TextCond)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TextData).HasMaxLength(4000);
            });

            modelBuilder.Entity<mTitle>(entity =>
            {
                entity.HasKey(e => e.Title_Code);

                entity.ToTable("mTitle");

                entity.Property(e => e.Title_Code).HasMaxLength(3);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Title_Name).HasMaxLength(35);

                entity.Property(e => e.Title_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mTranType>(entity =>
            {
                entity.HasKey(e => e.Tran_Code);

                entity.ToTable("mTranType");

                entity.Property(e => e.Tran_Code).HasMaxLength(3);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Tran_Desc).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<mUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("mUser");

                entity.Property(e => e.UserId).HasMaxLength(12);

                entity.Property(e => e.UserBran).HasMaxLength(4);

                entity.Property(e => e.UserDept).HasMaxLength(70);

                entity.Property(e => e.UserEmail).HasMaxLength(300);

                entity.Property(e => e.UserExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UserLevel).HasMaxLength(2);

                entity.Property(e => e.UserLockDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserName).HasMaxLength(70);

                entity.Property(e => e.UserPassword).HasMaxLength(60);

                entity.Property(e => e.UserPassword1).HasMaxLength(60);

                entity.Property(e => e.UserPassword2).HasMaxLength(60);

                entity.Property(e => e.UserPassword3).HasMaxLength(60);

                entity.Property(e => e.UserPasswordChangeDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserPasswordExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserRemark).HasMaxLength(200);

                entity.Property(e => e.UserStartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<mlogin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mlogin");

                entity.Property(e => e.password).HasMaxLength(20);

                entity.Property(e => e.username).HasMaxLength(20);
            });

            modelBuilder.Entity<pBLogLimit>(entity =>
            {
                entity.HasKey(e => new { e.LRecType, e.LLogSeq, e.LBank_Code, e.LFacility_No });

                entity.ToTable("pBLogLimit");

                entity.Property(e => e.LRecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LBank_Code).HasMaxLength(14);

                entity.Property(e => e.LFacility_No).HasMaxLength(13);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LBlockDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LBlock_Code)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LBlock_Note).HasMaxLength(350);

                entity.Property(e => e.LCCS_No).HasMaxLength(20);

                entity.Property(e => e.LCFRRate).HasMaxLength(10);

                entity.Property(e => e.LCondition).HasMaxLength(150);

                entity.Property(e => e.LCredit_Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.LCredit_Ccy).HasMaxLength(3);

                entity.Property(e => e.LCredit_Share).HasDefaultValueSql("((0))");

                entity.Property(e => e.LExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LFacility_Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LLimit_Code).HasMaxLength(10);

                entity.Property(e => e.LOrigin_Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.LRemark).HasMaxLength(350);

                entity.Property(e => e.LRevol_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LSseqno).HasDefaultValueSql("((0))");

                entity.Property(e => e.LStartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.lCnty_Code).HasMaxLength(2);
            });

            modelBuilder.Entity<pBLogLmProduct>(entity =>
            {
                entity.HasKey(e => new { e.LRecType, e.LLogSeq, e.LBank_Code, e.LFacility_No, e.LseqNo, e.LProd_Code });

                entity.ToTable("pBLogLmProduct");

                entity.Property(e => e.LRecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LBank_Code).HasMaxLength(14);

                entity.Property(e => e.LFacility_No).HasMaxLength(13);

                entity.Property(e => e.LProd_Code).HasMaxLength(15);

                entity.Property(e => e.LCCS_Limit).HasMaxLength(3);

                entity.Property(e => e.LCCS_No).HasMaxLength(20);

                entity.Property(e => e.LCCS_Ref).HasMaxLength(10);

                entity.Property(e => e.LExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LProd_Limit).HasMaxLength(15);

                entity.Property(e => e.LStartDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pBankLSum>(entity =>
            {
                entity.HasKey(e => new { e.Bank_Code, e.Facility_No })
                    .HasName("PK_pBankLSum_1");

                entity.ToTable("pBankLSum");

                entity.Property(e => e.Bank_Code).HasMaxLength(14);

                entity.Property(e => e.Facility_No).HasMaxLength(13);

                entity.Property(e => e.DBE_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.DBE_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.DLC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.DLC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.EXPC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.EXPC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLS_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLS_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLT_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLT_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBL_Over).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMLC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMLC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMTR_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMTR_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.NLTR_book).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGBC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGBC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGLC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGLC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.XBCC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCP_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCP_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCP_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCP_Book).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<pBankLiab>(entity =>
            {
                entity.HasKey(e => new { e.Bank_Code, e.Facility_No, e.Currency });

                entity.ToTable("pBankLiab");

                entity.Property(e => e.Bank_Code).HasMaxLength(14);

                entity.Property(e => e.Facility_No).HasMaxLength(13);

                entity.Property(e => e.Currency).HasMaxLength(3);

                entity.Property(e => e.EXPC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.EXPC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLS_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLS_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLT_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLT_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBL_Over).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMLC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMLC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMTR_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMTR_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.NLTR_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGBC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGBC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGLC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGLC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.XBCC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCP_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCP_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCP_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCP_Book).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<pBankLimit>(entity =>
            {
                entity.HasKey(e => new { e.Bank_Code, e.Facility_No });

                entity.ToTable("pBankLimit");

                entity.Property(e => e.Bank_Code).HasMaxLength(14);

                entity.Property(e => e.Facility_No).HasMaxLength(13);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AutoRec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BlockDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Block_Code)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Block_Note).HasMaxLength(350);

                entity.Property(e => e.CCS_No).HasMaxLength(20);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Cnty_Code).HasMaxLength(2);

                entity.Property(e => e.Condition).HasMaxLength(150);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Credit_Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Credit_Ccy).HasMaxLength(3);

                entity.Property(e => e.ExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ExpiryDate2).HasColumnType("smalldatetime");

                entity.Property(e => e.Facility_Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Hold_Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Limit_Code).HasMaxLength(10);

                entity.Property(e => e.Origin_Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.RecCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Remark).HasMaxLength(350);

                entity.Property(e => e.Revol_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Susp_Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.UsingRec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<pBankLmProduct>(entity =>
            {
                entity.HasKey(e => new { e.Bank_Code, e.Facility_No, e.SeqNo, e.Prod_Code });

                entity.ToTable("pBankLmProduct");

                entity.Property(e => e.Bank_Code).HasMaxLength(14);

                entity.Property(e => e.Facility_No).HasMaxLength(13);

                entity.Property(e => e.Prod_Code).HasMaxLength(15);

                entity.Property(e => e.CCS_Limit).HasMaxLength(3);

                entity.Property(e => e.CCS_No).HasMaxLength(20);

                entity.Property(e => e.CCS_ref).HasMaxLength(10);

                entity.Property(e => e.ExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Prod_Limit).HasMaxLength(15);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pCLogLimit>(entity =>
            {
                entity.HasKey(e => new { e.LRecType, e.LLogSeq, e.LCust_Code, e.LFacility_No });

                entity.ToTable("pCLogLimit");

                entity.Property(e => e.LRecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LCust_Code).HasMaxLength(6);

                entity.Property(e => e.LFacility_No).HasMaxLength(13);

                entity.Property(e => e.AuthCode).HasMaxLength(8);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LBlockDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LBlock_Code)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LBlock_Note).HasMaxLength(350);

                entity.Property(e => e.LCCS_No).HasMaxLength(20);

                entity.Property(e => e.LCFRRate).HasMaxLength(10);

                entity.Property(e => e.LCampaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LCampaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LCondition).HasMaxLength(150);

                entity.Property(e => e.LCredit_Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.LCredit_Ccy).HasMaxLength(3);

                entity.Property(e => e.LCredit_Share).HasDefaultValueSql("((0))");

                entity.Property(e => e.LExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LFacility_Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LLimit_Code).HasMaxLength(10);

                entity.Property(e => e.LOrigin_Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.LParent_Id).HasMaxLength(6);

                entity.Property(e => e.LRemark).HasMaxLength(350);

                entity.Property(e => e.LRevol_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LShare_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LShare_Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LSseqno).HasDefaultValueSql("((0))");

                entity.Property(e => e.LStartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<pCLogLmCC>(entity =>
            {
                entity.HasKey(e => new { e.LRecType, e.LLogSeq, e.LCust_Code, e.LFacility_No, e.LseqNo, e.LProd_Mod, e.LProd_Ref })
                    .HasName("PK_pCLogProdCCS");

                entity.ToTable("pCLogLmCCS");

                entity.Property(e => e.LRecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LCust_Code).HasMaxLength(6);

                entity.Property(e => e.LFacility_No).HasMaxLength(13);

                entity.Property(e => e.LProd_Mod).HasMaxLength(15);

                entity.Property(e => e.LProd_Ref).HasMaxLength(5);

                entity.Property(e => e.LCCS_Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LCCS_DocStat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LCCS_LmType).HasMaxLength(3);

                entity.Property(e => e.LCCS_No).HasMaxLength(20);

                entity.Property(e => e.LCCS_Stat).HasMaxLength(10);
            });

            modelBuilder.Entity<pCLogLmProduct>(entity =>
            {
                entity.HasKey(e => new { e.LRecType, e.LLogSeq, e.LCust_Code, e.LFacility_No, e.LseqNo, e.LProd_Code });

                entity.ToTable("pCLogLmProduct");

                entity.Property(e => e.LRecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LCust_Code).HasMaxLength(6);

                entity.Property(e => e.LFacility_No).HasMaxLength(13);

                entity.Property(e => e.LProd_Code).HasMaxLength(15);

                entity.Property(e => e.LCCS_Limit).HasMaxLength(3);

                entity.Property(e => e.LCCS_No).HasMaxLength(20);

                entity.Property(e => e.LCCS_Ref).HasMaxLength(10);

                entity.Property(e => e.LExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LProd_Limit).HasMaxLength(15);

                entity.Property(e => e.LStartDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pCLogShare>(entity =>
            {
                entity.HasKey(e => new { e.LRecType, e.LLogSeq, e.LCust_Code, e.LFacility_No, e.LSeqNo });

                entity.ToTable("pCLogShare");

                entity.Property(e => e.LRecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LCust_Code).HasMaxLength(6);

                entity.Property(e => e.LFacility_No).HasMaxLength(13);

                entity.Property(e => e.LShare_CCS).HasMaxLength(20);

                entity.Property(e => e.LShare_Cust).HasMaxLength(6);

                entity.Property(e => e.LShare_Dlc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LShare_Exp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LShare_Imp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LShare_LG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LShare_Limit).HasMaxLength(10);

                entity.Property(e => e.LShare_Mode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<pControlPack>(entity =>
            {
                entity.HasKey(e => e.ContNo);

                entity.ToTable("pControlPack");

                entity.Property(e => e.ContNo).HasMaxLength(15);

                entity.Property(e => e.AppName).HasMaxLength(50);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.CntyCode).HasMaxLength(50);

                entity.Property(e => e.ContDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ContStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ContTime)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CustCode).HasMaxLength(13);

                entity.Property(e => e.CustInfo).HasMaxLength(170);

                entity.Property(e => e.DocCcy).HasMaxLength(3);

                entity.Property(e => e.Expirydate).HasColumnType("smalldatetime");

                entity.Property(e => e.GoodCode).HasMaxLength(50);

                entity.Property(e => e.GoodDesc).HasMaxLength(200);

                entity.Property(e => e.InUser)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IssueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PackUnder).HasMaxLength(35);

                entity.Property(e => e.ReferLcNo).HasMaxLength(35);

                entity.Property(e => e.RelCode).HasMaxLength(6);

                entity.Property(e => e.ShipmentFr).HasMaxLength(70);

                entity.Property(e => e.ShipmentTo).HasMaxLength(70);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<pCustAppv>(entity =>
            {
                entity.HasKey(e => e.Appv_No);

                entity.ToTable("pCustAppv");

                entity.Property(e => e.Appv_No).HasMaxLength(15);

                entity.Property(e => e.Appv_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.Appv_CanDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Appv_Cancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Appv_Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Bank_Code).HasMaxLength(14);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.Comment).HasMaxLength(500);

                entity.Property(e => e.Credit_Line).HasDefaultValueSql("((0))");

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.EntryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Event)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.Facility_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Facility_No).HasMaxLength(13);

                entity.Property(e => e.Hold_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.Hold_Cust).HasMaxLength(6);

                entity.Property(e => e.Hold_FacNo).HasMaxLength(13);

                entity.Property(e => e.Liab_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Refer_BhtAmt).HasDefaultValueSql("((0))");

                entity.Property(e => e.Refer_Ccy).HasMaxLength(3);

                entity.Property(e => e.Refer_CcyAmt).HasDefaultValueSql("((0))");

                entity.Property(e => e.Refer_DocNo).HasMaxLength(20);

                entity.Property(e => e.Refer_ExchRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.Refer_RefNo).HasMaxLength(16);

                entity.Property(e => e.Refer_Type).HasMaxLength(5);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.Reverse_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.Share_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.Share_Type).HasMaxLength(10);

                entity.Property(e => e.TotAppv_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotCredit_Line).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotHold_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotLiab_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotShare_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.TxHold_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<pCustAppvDet>(entity =>
            {
                entity.HasKey(e => new { e.Appv_No, e.Cust_Code });

                entity.ToTable("pCustAppvDet");

                entity.Property(e => e.Appv_No).HasMaxLength(15);

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.EXPC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.EXPC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.Facility_No).HasMaxLength(13);

                entity.Property(e => e.IBLS_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLS_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLT_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLT_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBL_Over).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMLC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMLC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMTR_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMTR_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGBC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGBC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCP_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCP_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCP_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCP_Book).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<pCustLSum>(entity =>
            {
                entity.HasKey(e => new { e.Cust_Code, e.Facility_No });

                entity.ToTable("pCustLSum");

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.Facility_No).HasMaxLength(13);

                entity.Property(e => e.DBE_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.DBE_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.DLC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.DLC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.EXPC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.EXPC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLS_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLS_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLT_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLT_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBL_Over).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMLC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMLC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMTR_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMTR_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.NLTR_book).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGBC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGBC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGLC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGLC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.XBCC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCP_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCP_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCP_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCP_Book).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<pCustLiab>(entity =>
            {
                entity.HasKey(e => new { e.Cust_Code, e.Facility_No, e.Currency });

                entity.ToTable("pCustLiab");

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.Facility_No).HasMaxLength(13);

                entity.Property(e => e.Currency).HasMaxLength(3);

                entity.Property(e => e.EXPC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.EXPC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLS_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLS_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLT_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLT_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBL_Over).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMLC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMLC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMTR_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMTR_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.NLTR_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGBC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGBC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGLC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGLC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.XBCC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCP_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCP_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCP_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCP_Book).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<pCustLimit>(entity =>
            {
                entity.HasKey(e => new { e.Cust_Code, e.Facility_No });

                entity.ToTable("pCustLimit");

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.Facility_No).HasMaxLength(13);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AutoRec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BlockDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Block_Code)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Block_Note).HasMaxLength(350);

                entity.Property(e => e.CCS_No).HasMaxLength(20);

                entity.Property(e => e.CFRRate).HasMaxLength(10);

                entity.Property(e => e.CLMS_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Condition).HasMaxLength(150);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Credit_Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Credit_Ccy).HasMaxLength(3);

                entity.Property(e => e.Credit_Share).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ExpiryDate2).HasColumnType("smalldatetime");

                entity.Property(e => e.Facility_Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Hold_Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Limit_Code).HasMaxLength(10);

                entity.Property(e => e.Origin_Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Parent_Id).HasMaxLength(6);

                entity.Property(e => e.RecCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Refer_Cust).HasMaxLength(6);

                entity.Property(e => e.Refer_Facility).HasMaxLength(13);

                entity.Property(e => e.Remark).HasMaxLength(350);

                entity.Property(e => e.Revol_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Share_Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Share_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Share_Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Susp_Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.UsingRec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<pCustLmCC>(entity =>
            {
                entity.HasKey(e => new { e.Cust_Code, e.Facility_No, e.SeqNo, e.Prod_Mod, e.Prod_Ref });

                entity.ToTable("pCustLmCCS");

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.Facility_No).HasMaxLength(13);

                entity.Property(e => e.Prod_Mod).HasMaxLength(15);

                entity.Property(e => e.Prod_Ref).HasMaxLength(5);

                entity.Property(e => e.CCS_Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCS_DocStat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCS_LmType).HasMaxLength(3);

                entity.Property(e => e.CCS_No).HasMaxLength(20);

                entity.Property(e => e.CCS_Stat).HasMaxLength(10);
            });

            modelBuilder.Entity<pCustLmProduct>(entity =>
            {
                entity.HasKey(e => new { e.Cust_Code, e.Facility_No, e.SeqNo, e.Prod_Code });

                entity.ToTable("pCustLmProduct");

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.Facility_No).HasMaxLength(13);

                entity.Property(e => e.Prod_Code).HasMaxLength(15);

                entity.Property(e => e.CCS_Limit).HasMaxLength(3);

                entity.Property(e => e.CCS_No).HasMaxLength(20);

                entity.Property(e => e.CCS_ref).HasMaxLength(10);

                entity.Property(e => e.ExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Prod_Limit).HasMaxLength(15);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pCustShare>(entity =>
            {
                entity.HasKey(e => new { e.Cust_Code, e.Facility_No, e.Seqno });

                entity.ToTable("pCustShare");

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.Facility_No).HasMaxLength(13);

                entity.Property(e => e.Share_CCS).HasMaxLength(20);

                entity.Property(e => e.Share_Credit).HasDefaultValueSql("((0))");

                entity.Property(e => e.Share_Cust)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Share_Dlc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Share_Exp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Share_Imp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Share_LG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Share_Limit)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Share_Mode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Share_Used).HasDefaultValueSql("((0))");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<pDMSFLA>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pDMSFLA");

                entity.Property(e => e.ACCDCounterpartyType).HasMaxLength(50);

                entity.Property(e => e.ACCDLicenseScheme).HasMaxLength(50);

                entity.Property(e => e.ArrangeContDate).HasMaxLength(8);

                entity.Property(e => e.ArrangeTerm).HasMaxLength(3);

                entity.Property(e => e.ArrangeTermType).HasMaxLength(6);

                entity.Property(e => e.ArrangeTermUnit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AsAtDate).HasMaxLength(10);

                entity.Property(e => e.CallOpWholeFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CentralID).HasMaxLength(9);

                entity.Property(e => e.ContractCcyID).HasMaxLength(3);

                entity.Property(e => e.CreditType).HasMaxLength(8);

                entity.Property(e => e.DataProviderBranchNumber).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.EffectiveDate).HasMaxLength(8);

                entity.Property(e => e.EventType).HasMaxLength(25);

                entity.Property(e => e.ExtendedFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FIArrangementNo).HasMaxLength(15);

                entity.Property(e => e.FirstDisburseDate).HasMaxLength(8);

                entity.Property(e => e.FirstRepaymentDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntRateType).HasMaxLength(10);

                entity.Property(e => e.IntRepayTerm).HasMaxLength(3);

                entity.Property(e => e.IntRepayTermUnit).HasMaxLength(1);

                entity.Property(e => e.Keynumber).HasMaxLength(15);

                entity.Property(e => e.LoanCallOptExAmt).HasMaxLength(8);

                entity.Property(e => e.LoanCallOptExDate).HasMaxLength(8);

                entity.Property(e => e.LoanPutOptExDate).HasMaxLength(8);

                entity.Property(e => e.LoanType).HasMaxLength(6);

                entity.Property(e => e.MaturityDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PeriodFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PrevArrangeNum).HasMaxLength(6);

                entity.Property(e => e.PrimaryInvoBrnNum).HasMaxLength(6);

                entity.Property(e => e.PrimaryInvoIBF).HasMaxLength(6);

                entity.Property(e => e.PrnRepayTermUnit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Product).HasMaxLength(4);

                entity.Property(e => e.PutOpWholeFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RelInvoPartyName).HasMaxLength(50);

                entity.Property(e => e.RunDate).HasMaxLength(10);

                entity.Property(e => e.RunTime)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.System).HasMaxLength(6);

                entity.Property(e => e.TXSeq).HasMaxLength(4);
            });

            modelBuilder.Entity<pDMSFTU>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pDMSFTU");

                entity.Property(e => e.AsAtDate).HasMaxLength(10);

                entity.Property(e => e.BenCnty).HasMaxLength(2);

                entity.Property(e => e.CurID).HasMaxLength(3);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.EventType).HasMaxLength(25);

                entity.Property(e => e.ExcInvPartyBusType).HasMaxLength(7);

                entity.Property(e => e.FXArrangeType).HasMaxLength(6);

                entity.Property(e => e.InFlowTXPurpose).HasMaxLength(6);

                entity.Property(e => e.Keynumber).HasMaxLength(15);

                entity.Property(e => e.LegType).HasMaxLength(6);

                entity.Property(e => e.OutFlowTXPurpose).HasMaxLength(6);

                entity.Property(e => e.PeriodFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Product).HasMaxLength(4);

                entity.Property(e => e.RunDate).HasMaxLength(10);

                entity.Property(e => e.RunTime_U)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.System).HasMaxLength(6);

                entity.Property(e => e.TXSeq).HasMaxLength(4);
            });

            modelBuilder.Entity<pDMSFTX>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pDMSFTX");

                entity.Property(e => e.ACCDCounterpartyType).HasMaxLength(200);

                entity.Property(e => e.ACCDLicenseScheme).HasMaxLength(200);

                entity.Property(e => e.AppvDocDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AppvDocNo).HasMaxLength(15);

                entity.Property(e => e.AsAtDate).HasMaxLength(10);

                entity.Property(e => e.BenCnty).HasMaxLength(2);

                entity.Property(e => e.BenName).HasMaxLength(200);

                entity.Property(e => e.BotReferenceNumber).HasMaxLength(50);

                entity.Property(e => e.BuyCurID).HasMaxLength(3);

                entity.Property(e => e.CancelationReasonType).HasMaxLength(50);

                entity.Property(e => e.CancellationReasonType).HasMaxLength(200);

                entity.Property(e => e.CentralID).HasMaxLength(50);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.CustInvestType)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DebtInstruIssueDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.EventType).HasMaxLength(25);

                entity.Property(e => e.ExcInvPartyBrNo).HasMaxLength(4);

                entity.Property(e => e.ExcInvPartyBusType).HasMaxLength(7);

                entity.Property(e => e.ExcInvPartyIBFInd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ExcInvPartyName).HasMaxLength(70);

                entity.Property(e => e.FIArrangementNo).HasMaxLength(15);

                entity.Property(e => e.FXArrangeType).HasMaxLength(6);

                entity.Property(e => e.FXTradingTXType).HasMaxLength(6);

                entity.Property(e => e.FirstDisburDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FirstInstallDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FromTXType).HasMaxLength(6);

                entity.Property(e => e.FromToAccNo).HasMaxLength(19);

                entity.Property(e => e.FromToFICode).HasMaxLength(6);

                entity.Property(e => e.FromToRelTXDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.InFlowTXPurpose).HasMaxLength(6);

                entity.Property(e => e.InstallTermUnit)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntRateType).HasMaxLength(10);

                entity.Property(e => e.InvestReason).HasMaxLength(200);

                entity.Property(e => e.KeyInTimestamp).HasMaxLength(200);

                entity.Property(e => e.Keynumber).HasMaxLength(15);

                entity.Property(e => e.ListinMarketFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LoanDecType)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MaturityDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NoofInstall)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NoofShare).HasMaxLength(3);

                entity.Property(e => e.NotionalCurID).HasMaxLength(3);

                entity.Property(e => e.ObjectiveType).HasMaxLength(50);

                entity.Property(e => e.OthTXPurposeDesc).HasMaxLength(200);

                entity.Property(e => e.OutFlowTXPurpose).HasMaxLength(6);

                entity.Property(e => e.OutsNotCurID).HasMaxLength(3);

                entity.Property(e => e.ParValue).HasMaxLength(3);

                entity.Property(e => e.PaymentMeth).HasMaxLength(6);

                entity.Property(e => e.PeriodFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PreviousArrangementFICode).HasMaxLength(200);

                entity.Property(e => e.PreviousArrangementNumber).HasMaxLength(200);

                entity.Property(e => e.Product).HasMaxLength(4);

                entity.Property(e => e.RePayDueIndicator)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RelInvPartyBusType).HasMaxLength(7);

                entity.Property(e => e.RelInvPartyName).HasMaxLength(70);

                entity.Property(e => e.RelationRelInvParty).HasMaxLength(6);

                entity.Property(e => e.RelationwithBen).HasMaxLength(6);

                entity.Property(e => e.RunDate).HasMaxLength(10);

                entity.Property(e => e.RunTime)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SellCurID).HasMaxLength(3);

                entity.Property(e => e.SetUpReasonType).HasMaxLength(200);

                entity.Property(e => e.System).HasMaxLength(6);

                entity.Property(e => e.TXDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TXPurposeCode).HasMaxLength(6);

                entity.Property(e => e.TXSeq).HasMaxLength(4);

                entity.Property(e => e.TermRange)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ToTXType).HasMaxLength(6);

                entity.Property(e => e.UnderlyingOwnerName).HasMaxLength(50);

                entity.Property(e => e.WholePartRepayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<pDMSFTXLimit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pDMSFTXLimit");

                entity.Property(e => e.Delete_Flag).HasMaxLength(50);

                entity.Property(e => e.Event_No).HasMaxLength(50);
            });

            modelBuilder.Entity<pDMSLTX>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pDMSLTX");

                entity.Property(e => e.AppvDocDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AppvDocNo).HasMaxLength(15);

                entity.Property(e => e.AsAtDate).HasMaxLength(10);

                entity.Property(e => e.BenCnty).HasMaxLength(20);

                entity.Property(e => e.BenName).HasMaxLength(200);

                entity.Property(e => e.BotReferenceNumber).HasMaxLength(200);

                entity.Property(e => e.CurrencyID).HasMaxLength(3);

                entity.Property(e => e.CustInvestType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DataProviderBranchNumber).HasMaxLength(200);

                entity.Property(e => e.DebtInstruIssueDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.EventType).HasMaxLength(25);

                entity.Property(e => e.FIArrangementNo).HasMaxLength(15);

                entity.Property(e => e.FirstDisburDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FirstInstallDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FromTXType).HasMaxLength(6);

                entity.Property(e => e.FromToAccNo).HasMaxLength(19);

                entity.Property(e => e.FromToFICode).HasMaxLength(6);

                entity.Property(e => e.FromToRelTXDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.InFlowTXPurpose).HasMaxLength(6);

                entity.Property(e => e.InstallTermUnit)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.InstallmentNo).HasMaxLength(2);

                entity.Property(e => e.IntRateType).HasMaxLength(10);

                entity.Property(e => e.InvestReason).HasMaxLength(200);

                entity.Property(e => e.Keynumber).HasMaxLength(15);

                entity.Property(e => e.ListinMarketFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LoanDecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LoanDepositTrxType).HasMaxLength(6);

                entity.Property(e => e.MaturityDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NoOfShare).HasMaxLength(3);

                entity.Property(e => e.NoofInstall)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.OthRepayResonDesc).HasMaxLength(50);

                entity.Property(e => e.OthTXPurposeDesc).HasMaxLength(200);

                entity.Property(e => e.OutFlowTXPurpose).HasMaxLength(6);

                entity.Property(e => e.ParValue).HasMaxLength(3);

                entity.Property(e => e.PaymentMeth).HasMaxLength(6);

                entity.Property(e => e.PeriodFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Product).HasMaxLength(4);

                entity.Property(e => e.RePayDueIndicator)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RelationwithBen).HasMaxLength(6);

                entity.Property(e => e.RepaymentReson).HasMaxLength(6);

                entity.Property(e => e.ResCentralID).HasMaxLength(8);

                entity.Property(e => e.RunDate).HasMaxLength(10);

                entity.Property(e => e.RunTime)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.System).HasMaxLength(6);

                entity.Property(e => e.TXPurposeCode).HasMaxLength(6);

                entity.Property(e => e.TXSeq).HasMaxLength(4);

                entity.Property(e => e.TermRange)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ToTXType).HasMaxLength(6);

                entity.Property(e => e.TransactionDate).HasMaxLength(8);

                entity.Property(e => e.UnderlyingOwnerName).HasMaxLength(200);

                entity.Property(e => e.WholePartRepayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<pDMSPTX>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pDMSPTX");

                entity.Property(e => e.AsAtDate).HasMaxLength(10);

                entity.Property(e => e.CntryIDOfInvolParty).HasMaxLength(2);

                entity.Property(e => e.CountryIdofIssuerorInvestedOrganization).HasMaxLength(2);

                entity.Property(e => e.CouponRate).HasMaxLength(20);

                entity.Property(e => e.CurrencyId).HasMaxLength(3);

                entity.Property(e => e.DebtInstrumentName).HasMaxLength(70);

                entity.Property(e => e.DebtInstrumentType).HasMaxLength(20);

                entity.Property(e => e.DefaultedBillPurchaseDate).HasMaxLength(8);

                entity.Property(e => e.EventType).HasMaxLength(25);

                entity.Property(e => e.ISINCode).HasMaxLength(10);

                entity.Property(e => e.IntentionCountryId).HasMaxLength(2);

                entity.Property(e => e.InvolPartyID).HasMaxLength(20);

                entity.Property(e => e.InvolPartyName).HasMaxLength(70);

                entity.Property(e => e.IssueDate).HasMaxLength(8);

                entity.Property(e => e.IssuerorInvestedOrganizationName).HasMaxLength(70);

                entity.Property(e => e.Keynumber).HasMaxLength(15);

                entity.Property(e => e.MaturityDate).HasMaxLength(8);

                entity.Property(e => e.NostroAcc).HasMaxLength(15);

                entity.Property(e => e.OriginalTerm).HasMaxLength(3);

                entity.Property(e => e.OriginalTermUnit).HasMaxLength(3);

                entity.Property(e => e.PaymentMethod).HasMaxLength(6);

                entity.Property(e => e.PeriodFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Product).HasMaxLength(4);

                entity.Property(e => e.RecpPayTrnCode).HasMaxLength(6);

                entity.Property(e => e.RecpPayTrnDate).HasMaxLength(10);

                entity.Property(e => e.RecpPayTrnItmDesc).HasMaxLength(50);

                entity.Property(e => e.RecpPayTrnItmType).HasMaxLength(6);

                entity.Property(e => e.RecpPayTrnType).HasMaxLength(6);

                entity.Property(e => e.RunDate).HasMaxLength(10);

                entity.Property(e => e.RunTime_U)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SellForeignCurSecTransAmtinBahtEqui).HasMaxLength(20);

                entity.Property(e => e.System).HasMaxLength(6);

                entity.Property(e => e.UnitofTransaction).HasMaxLength(5);
            });

            modelBuilder.Entity<pDOMBE>(entity =>
            {
                entity.HasKey(e => new { e.BENumber, e.RecType, e.BESeqno });

                entity.ToTable("pDOMBE");

                entity.Property(e => e.BENumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AdviceDisc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AdviceResult)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Allocation).HasMaxLength(10);

                entity.Property(e => e.AppvNo).HasMaxLength(15);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AutoOverDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BECcy).HasMaxLength(3);

                entity.Property(e => e.BEOverDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BEStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BPOFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BenCnty).HasMaxLength(2);

                entity.Property(e => e.BenInfo).HasMaxLength(144);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(20);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(20);

                entity.Property(e => e.CCS_LmType).HasMaxLength(3);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.ChkDeduct)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CommDesc).HasMaxLength(200);

                entity.Property(e => e.CustAddr).HasMaxLength(144);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.DLCNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DMS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DateGenAc).HasColumnType("smalldatetime");

                entity.Property(e => e.DateLastAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateLastPaid).HasColumnType("smalldatetime");

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateToStop).HasColumnType("smalldatetime");

                entity.Property(e => e.Discrepancy).HasMaxLength(1000);

                entity.Property(e => e.DocCCy).HasMaxLength(3);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Event).HasMaxLength(25);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventFlag).HasMaxLength(7);

                entity.Property(e => e.EventMode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FCYReceiptNo).HasMaxLength(15);

                entity.Property(e => e.FacNo).HasMaxLength(13);

                entity.Property(e => e.GenAccFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Instruction).HasMaxLength(1000);

                entity.Property(e => e.IntFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntRateCode).HasMaxLength(10);

                entity.Property(e => e.IntStartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LastIntDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LastReceiptNo).HasMaxLength(15);

                entity.Property(e => e.NegoDate).HasColumnType("smalldatetime");

                entity.Property(e => e.OverdueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PastDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PastDueFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayMethod).HasMaxLength(15);

                entity.Property(e => e.PaymentFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PrevDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReferBE).HasMaxLength(20);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.SwFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TRFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TaxRefund)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenorTerm).HasMaxLength(30);

                entity.Property(e => e.TenorType).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.ValueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.VoucherID).HasMaxLength(15);
            });

            modelBuilder.Entity<pDOMLC>(entity =>
            {
                entity.HasKey(e => new { e.DLCNumber, e.RecType, e.DLCSeqno });

                entity.ToTable("pDOMLC");

                entity.Property(e => e.DLCNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AOCode).HasMaxLength(5);

                entity.Property(e => e.Allocation).HasMaxLength(13);

                entity.Property(e => e.AmendFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AmendNo).HasMaxLength(15);

                entity.Property(e => e.AppvNo).HasMaxLength(15);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.BPOFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BenCode).HasMaxLength(6);

                entity.Property(e => e.BenInfo).HasMaxLength(300);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(20);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(20);

                entity.Property(e => e.CCS_LmType).HasMaxLength(3);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.CustAddr).HasMaxLength(144);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.DEPlus_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DLCCcy).HasMaxLength(3);

                entity.Property(e => e.DLCMove)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DLCRefNo).HasMaxLength(20);

                entity.Property(e => e.DLCStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DMS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DateExpiry).HasColumnType("smalldatetime");

                entity.Property(e => e.DateGenAcc).HasColumnType("smalldatetime");

                entity.Property(e => e.DateIssue).HasColumnType("smalldatetime");

                entity.Property(e => e.DateLastPaid).HasColumnType("smalldatetime");

                entity.Property(e => e.DateLateShip).HasColumnType("smalldatetime");

                entity.Property(e => e.Event).HasMaxLength(25);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventFlag).HasMaxLength(7);

                entity.Property(e => e.EventMode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FacNo).HasMaxLength(13);

                entity.Property(e => e.GenAccFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.GoodsCode).HasMaxLength(3);

                entity.Property(e => e.GoodsDesc).HasMaxLength(2000);

                entity.Property(e => e.InUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.InvoiceInfo).HasMaxLength(2000);

                entity.Property(e => e.LOCode).HasMaxLength(8);

                entity.Property(e => e.LastReceiptNo).HasMaxLength(15);

                entity.Property(e => e.NoVary)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PartialShipment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayMethod).HasMaxLength(15);

                entity.Property(e => e.PayRemark).HasMaxLength(200);

                entity.Property(e => e.PrevBenCode).HasMaxLength(6);

                entity.Property(e => e.PrevBenInfo).HasMaxLength(300);

                entity.Property(e => e.PrevDateExpiry).HasColumnType("smalldatetime");

                entity.Property(e => e.PurposeCode).HasMaxLength(6);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ShipmentFrom).HasMaxLength(70);

                entity.Property(e => e.ShipmentTo).HasMaxLength(70);

                entity.Property(e => e.SpecialInfo).HasMaxLength(2000);

                entity.Property(e => e.TRAppvNo).HasMaxLength(15);

                entity.Property(e => e.TaxRefund)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenorTerm).HasMaxLength(30);

                entity.Property(e => e.TenorType).HasMaxLength(20);

                entity.Property(e => e.TranShipment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.VoucherID).HasMaxLength(15);
            });

            modelBuilder.Entity<pDailyGL>(entity =>
            {
                entity.HasKey(e => new { e.VouchDate, e.VouchID, e.TranSeq, e.TranDocNo, e.TranDocseq })
                    .HasName("PK_pDayGL");

                entity.ToTable("pDailyGL");

                entity.Property(e => e.VouchDate).HasColumnType("smalldatetime");

                entity.Property(e => e.VouchID).HasMaxLength(15);

                entity.Property(e => e.TranDocNo).HasMaxLength(15);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CustCode).HasMaxLength(8);

                entity.Property(e => e.GFMS_Bran).HasMaxLength(4);

                entity.Property(e => e.GFMS_Map).HasMaxLength(11);

                entity.Property(e => e.InvoiceNo).HasMaxLength(15);

                entity.Property(e => e.LoanStat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NostroBank).HasMaxLength(13);

                entity.Property(e => e.ProdCode).HasMaxLength(6);

                entity.Property(e => e.RCCode).HasMaxLength(5);

                entity.Property(e => e.SBUCode).HasMaxLength(4);

                entity.Property(e => e.SendFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Tag20Ref).HasMaxLength(20);

                entity.Property(e => e.TranAccount).HasMaxLength(15);

                entity.Property(e => e.TranAllocate).HasMaxLength(15);

                entity.Property(e => e.TranBran).HasMaxLength(4);

                entity.Property(e => e.TranCcy).HasMaxLength(3);

                entity.Property(e => e.TranCenter).HasMaxLength(4);

                entity.Property(e => e.TranCond).HasMaxLength(20);

                entity.Property(e => e.TranDept).HasMaxLength(4);

                entity.Property(e => e.TranDesc).HasMaxLength(50);

                entity.Property(e => e.TranEvent).HasMaxLength(20);

                entity.Property(e => e.TranMod).HasMaxLength(5);

                entity.Property(e => e.TranNature)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TranRef).HasMaxLength(15);

                entity.Property(e => e.TranStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Wref_Bank_ID).HasMaxLength(14);
            });

            modelBuilder.Entity<pDailyGL4>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pDailyGL4");

                entity.Property(e => e.CreateDate).HasMaxLength(255);

                entity.Property(e => e.CustCode).HasMaxLength(255);

                entity.Property(e => e.SendFlag).HasMaxLength(255);

                entity.Property(e => e.TranAccount).HasMaxLength(255);

                entity.Property(e => e.TranAllocate).HasMaxLength(255);

                entity.Property(e => e.TranAmount).HasMaxLength(255);

                entity.Property(e => e.TranBran).HasMaxLength(255);

                entity.Property(e => e.TranCcy).HasMaxLength(255);

                entity.Property(e => e.TranCenter).HasMaxLength(255);

                entity.Property(e => e.TranCond).HasMaxLength(255);

                entity.Property(e => e.TranDept).HasMaxLength(255);

                entity.Property(e => e.TranDesc).HasMaxLength(255);

                entity.Property(e => e.TranDocNo).HasMaxLength(255);

                entity.Property(e => e.TranDocseq).HasMaxLength(255);

                entity.Property(e => e.TranEvent).HasMaxLength(255);

                entity.Property(e => e.TranExch).HasMaxLength(255);

                entity.Property(e => e.TranMod).HasMaxLength(255);

                entity.Property(e => e.TranNature).HasMaxLength(255);

                entity.Property(e => e.TranRef).HasMaxLength(255);

                entity.Property(e => e.TranSeq).HasMaxLength(255);

                entity.Property(e => e.TranStatus).HasMaxLength(255);

                entity.Property(e => e.VouchDate).HasMaxLength(255);

                entity.Property(e => e.VouchID).HasMaxLength(255);
            });

            modelBuilder.Entity<pDailyGLMap>(entity =>
            {
                entity.HasKey(e => new { e.VouchDate, e.VouchID, e.TranSeq, e.TranDocNo, e.TranDocseq });

                entity.ToTable("pDailyGLMap");

                entity.Property(e => e.VouchDate).HasColumnType("smalldatetime");

                entity.Property(e => e.VouchID).HasMaxLength(15);

                entity.Property(e => e.TranDocNo).HasMaxLength(15);

                entity.Property(e => e.TranBSArea).HasMaxLength(4);

                entity.Property(e => e.TranBSLine).HasMaxLength(10);

                entity.Property(e => e.TranCost).HasMaxLength(10);

                entity.Property(e => e.TranIndex2).HasMaxLength(15);

                entity.Property(e => e.TranMod).HasMaxLength(5);

                entity.Property(e => e.TranProd).HasMaxLength(10);

                entity.Property(e => e.TranProfit).HasMaxLength(10);

                entity.Property(e => e.TranSale).HasMaxLength(10);

                entity.Property(e => e.TranSapAcc).HasMaxLength(19);

                entity.Property(e => e.TranTerm).HasMaxLength(10);
            });

            modelBuilder.Entity<pDailyGLSum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pDailyGLSum");

                entity.Property(e => e.TranBSArea).HasMaxLength(4);

                entity.Property(e => e.TranBSLine).HasMaxLength(10);

                entity.Property(e => e.TranCcy).HasMaxLength(3);

                entity.Property(e => e.TranCost).HasMaxLength(10);

                entity.Property(e => e.TranIndex).HasMaxLength(5);

                entity.Property(e => e.TranIndex2).HasMaxLength(15);

                entity.Property(e => e.TranNature)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TranProd).HasMaxLength(10);

                entity.Property(e => e.TranProfit).HasMaxLength(10);

                entity.Property(e => e.TranSale).HasMaxLength(10);

                entity.Property(e => e.TranSapAcc).HasMaxLength(19);

                entity.Property(e => e.TranTerm).HasMaxLength(10);

                entity.Property(e => e.VouchDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pDailySap>(entity =>
            {
                entity.HasKey(e => new { e.VouchDate, e.RecNo });

                entity.ToTable("pDailySap");

                entity.Property(e => e.VouchDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TranAccount).HasMaxLength(15);

                entity.Property(e => e.TranAllocate).HasMaxLength(10);

                entity.Property(e => e.TranBatch).HasMaxLength(15);

                entity.Property(e => e.TranCcy).HasMaxLength(3);

                entity.Property(e => e.TranCenter).HasMaxLength(4);

                entity.Property(e => e.TranEvent).HasMaxLength(20);

                entity.Property(e => e.TranMod).HasMaxLength(5);

                entity.Property(e => e.TranNature)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<pDailySapHead>(entity =>
            {
                entity.HasKey(e => new { e.VouchDate, e.TranIndex });

                entity.ToTable("pDailySapHead");

                entity.Property(e => e.VouchDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TranIndex).HasMaxLength(5);

                entity.Property(e => e.TranCcy).HasMaxLength(3);
            });

            modelBuilder.Entity<pDailySapMap>(entity =>
            {
                entity.HasKey(e => new { e.VouchDate, e.RecNo })
                    .HasName("PK_pDailySapNew");

                entity.ToTable("pDailySapMap");

                entity.Property(e => e.VouchDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TranAccount).HasMaxLength(15);

                entity.Property(e => e.TranBSArea).HasMaxLength(4);

                entity.Property(e => e.TranBSLine).HasMaxLength(10);

                entity.Property(e => e.TranBatch).HasMaxLength(15);

                entity.Property(e => e.TranCcy).HasMaxLength(3);

                entity.Property(e => e.TranCost).HasMaxLength(10);

                entity.Property(e => e.TranExch)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TranIndex).HasMaxLength(5);

                entity.Property(e => e.TranNature)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TranProd).HasMaxLength(10);

                entity.Property(e => e.TranProfit).HasMaxLength(10);

                entity.Property(e => e.TranSale).HasMaxLength(10);

                entity.Property(e => e.TranTerm).HasMaxLength(10);
            });

            modelBuilder.Entity<pDetailForex>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pDetailForex");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<pDocRegInv>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pDocRegInv");

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.InvNumber).HasMaxLength(26);

                entity.Property(e => e.Reg_Docno)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<pDocRegInv1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pDocRegInv1");

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.InvNumber).HasMaxLength(20);

                entity.Property(e => e.Reg_Docno)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<pDocRegInv2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pDocRegInv2");

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.InvNumber).HasMaxLength(20);

                entity.Property(e => e.Reg_Docno)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<pDocRegister>(entity =>
            {
                entity.HasKey(e => new { e.Reg_Login, e.Reg_Funct, e.Reg_Docno });

                entity.ToTable("pDocRegister");

                entity.Property(e => e.Reg_Login)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Reg_Funct).HasMaxLength(6);

                entity.Property(e => e.Reg_Docno).HasMaxLength(15);

                entity.Property(e => e.ACCESS_ID)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.BPOFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CIF)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.Edition_Number)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Reg_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.Reg_Amt1).HasDefaultValueSql("((0))");

                entity.Property(e => e.Reg_Appv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Reg_AppvNo).HasMaxLength(15);

                entity.Property(e => e.Reg_BankCode).HasMaxLength(14);

                entity.Property(e => e.Reg_BhtAmt).HasDefaultValueSql("((0))");

                entity.Property(e => e.Reg_Ccy).HasMaxLength(3);

                entity.Property(e => e.Reg_CcyAmt).HasDefaultValueSql("((0))");

                entity.Property(e => e.Reg_CcyBal).HasDefaultValueSql("((0))");

                entity.Property(e => e.Reg_CustCode).HasMaxLength(6);

                entity.Property(e => e.Reg_Date).HasColumnType("smalldatetime");

                entity.Property(e => e.Reg_DocType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Reg_ExchRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.Reg_FacilityNo).HasMaxLength(13);

                entity.Property(e => e.Reg_Minus).HasDefaultValueSql("((0))");

                entity.Property(e => e.Reg_Plus).HasDefaultValueSql("((0))");

                entity.Property(e => e.Reg_RecStat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Reg_RefAmt).HasDefaultValueSql("((0))");

                entity.Property(e => e.Reg_RefNo).HasMaxLength(35);

                entity.Property(e => e.Reg_RefNo2).HasMaxLength(70);

                entity.Property(e => e.Reg_RefNo3).HasMaxLength(35);

                entity.Property(e => e.Reg_RefNo4).HasMaxLength(35);

                entity.Property(e => e.Reg_RefType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Reg_Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Reg_Tenor)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Reg_Time)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Remark).HasMaxLength(350);

                entity.Property(e => e.Trade_ref_Number)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.WithOut)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.WithOutFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.WithOutType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<pEXInterest>(entity =>
            {
                entity.HasKey(e => new { e.Login, e.Event, e.DocNo, e.EventNo, e.Seqno });

                entity.ToTable("pEXInterest");

                entity.Property(e => e.Login).HasMaxLength(4);

                entity.Property(e => e.Event).HasMaxLength(25);

                entity.Property(e => e.DocNo).HasMaxLength(15);

                entity.Property(e => e.CalDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.IntCode).HasMaxLength(10);

                entity.Property(e => e.IntFrom).HasColumnType("smalldatetime");

                entity.Property(e => e.IntTo).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pExPastDue>(entity =>
            {
                entity.HasKey(e => new { e.DocNumber, e.RecType, e.EventNo });

                entity.ToTable("pExPastDue");

                entity.Property(e => e.DocNumber).HasMaxLength(15);

                entity.Property(e => e.RecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AOCode).HasMaxLength(5);

                entity.Property(e => e.Allocation).HasMaxLength(10);

                entity.Property(e => e.AppName).HasMaxLength(175);

                entity.Property(e => e.AppvNo).HasMaxLength(15);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.BPOFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(20);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(20);

                entity.Property(e => e.CCS_LmType).HasMaxLength(3);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.CustAddr).HasMaxLength(144);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.DIntRateCode).HasMaxLength(10);

                entity.Property(e => e.DMS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DateLastAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateLastPaid).HasColumnType("smalldatetime");

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateToStop).HasColumnType("smalldatetime");

                entity.Property(e => e.DocCcy).HasMaxLength(3);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DueStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Event).HasMaxLength(25);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventMode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FModule).HasMaxLength(4);

                entity.Property(e => e.FacNo).HasMaxLength(13);

                entity.Property(e => e.GenAccFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.InUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntRateCode).HasMaxLength(10);

                entity.Property(e => e.IntStartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Invoice).HasMaxLength(70);

                entity.Property(e => e.IssBankID).HasMaxLength(13);

                entity.Property(e => e.LOCode).HasMaxLength(8);

                entity.Property(e => e.LastIntDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LastReceiptNo).HasMaxLength(15);

                entity.Property(e => e.Narrative).HasMaxLength(2100);

                entity.Property(e => e.OverdueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PastDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayMethod).HasMaxLength(15);

                entity.Property(e => e.PayType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RefLcNo).HasMaxLength(35);

                entity.Property(e => e.RefNumber).HasMaxLength(15);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TaxRefund)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenorType).HasMaxLength(15);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.ValueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.VoucherID).HasMaxLength(15);
            });

            modelBuilder.Entity<pExPayment>(entity =>
            {
                entity.HasKey(e => new { e.DOCNUMBER, e.EVENT_NO });

                entity.ToTable("pExPayment");

                entity.Property(e => e.DOCNUMBER).HasMaxLength(15);

                entity.Property(e => e.ACCOUNT_NO1).HasMaxLength(15);

                entity.Property(e => e.ACCOUNT_NO2).HasMaxLength(15);

                entity.Property(e => e.ACCOUNT_NO3).HasMaxLength(15);

                entity.Property(e => e.AcBahtnet).HasMaxLength(15);

                entity.Property(e => e.CHEQUE_BK_BRN).HasMaxLength(35);

                entity.Property(e => e.CHEQUE_NO).HasMaxLength(35);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.Debit_credit_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.EVENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.EVENT_TYPE).HasMaxLength(25);

                entity.Property(e => e.FORWARD_CONRACT_NO1).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO2).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO3).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO4).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO5).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO6).HasMaxLength(15);

                entity.Property(e => e.FcdAcc).HasMaxLength(15);

                entity.Property(e => e.MTFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Method).HasMaxLength(10);

                entity.Property(e => e.PAYMENT_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.PAYMENT_INSTRU).HasMaxLength(10);

                entity.Property(e => e.PAY_TYPE).HasDefaultValueSql("((0))");

                entity.Property(e => e.ParTnor_Type1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ParTnor_Type2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ParTnor_Type3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ParTnor_Type4)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ParTnor_Type5)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ParTnor_Type6)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RECEIVE_PAY_AMT).HasDefaultValueSql("((0))");

                entity.Property(e => e.REC_STATUS).HasMaxLength(10);

                entity.Property(e => e.SETTLEMENT_CREDIT).HasDefaultValueSql("((0))");

                entity.Property(e => e.SIGHT_FORWARD).HasMaxLength(15);

                entity.Property(e => e.SIGHT_PAID_AMT).HasDefaultValueSql("((0))");

                entity.Property(e => e.SIGHT_PAID_THB).HasDefaultValueSql("((0))");

                entity.Property(e => e.TERM_FORWARD).HasMaxLength(15);

                entity.Property(e => e.TERM_PAID_AMT).HasDefaultValueSql("((0))");

                entity.Property(e => e.TERM_PAID_THB).HasDefaultValueSql("((0))");

                entity.Property(e => e.TOT_PRINC_PAID).HasDefaultValueSql("((0))");

                entity.Property(e => e.fb_amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.fb_amt_thb).HasDefaultValueSql("((0))");

                entity.Property(e => e.fb_ccy).HasMaxLength(3);

                entity.Property(e => e.fb_rate).HasDefaultValueSql("((0))");

                entity.Property(e => e.over_paid_amt).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<pExad>(entity =>
            {
                entity.HasKey(e => new { e.RECORD_TYPE, e.REC_STATUS, e.EXPORT_ADVICE_NO, e.EVENT_NO });

                entity.ToTable("pExad");

                entity.Property(e => e.RECORD_TYPE).HasMaxLength(10);

                entity.Property(e => e.REC_STATUS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.EXPORT_ADVICE_NO).HasMaxLength(15);

                entity.Property(e => e.ADVICE_METHOD).HasMaxLength(15);

                entity.Property(e => e.ADVISE_THRU_ADDRESS).HasMaxLength(180);

                entity.Property(e => e.ADVISE_THRU_CITY).HasMaxLength(35);

                entity.Property(e => e.ADVISE_THRU_COUNTRY_CODE).HasMaxLength(2);

                entity.Property(e => e.ADVISE_THRU_THRU_BK_ID).HasMaxLength(13);

                entity.Property(e => e.ADVISE_THRU_THRU_BK_NAME).HasMaxLength(35);

                entity.Property(e => e.ADVISING_DATE).HasColumnType("datetime");

                entity.Property(e => e.ALLOCATION).HasMaxLength(10);

                entity.Property(e => e.AMEND_DATE).HasColumnType("datetime");

                entity.Property(e => e.APPLICANT_ADDRESS).HasMaxLength(105);

                entity.Property(e => e.APPLICANT_NAME).HasMaxLength(75);

                entity.Property(e => e.AUTH_CODE).HasMaxLength(12);

                entity.Property(e => e.AUTH_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.AdviceOther)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AutoOverDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BENEFICIARY_ID).HasMaxLength(13);

                entity.Property(e => e.BENEFICIARY_INFO).HasMaxLength(180);

                entity.Property(e => e.BPOFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BUSINESS_TYPE).HasMaxLength(4);

                entity.Property(e => e.Bank_Code).HasMaxLength(14);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(20);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(20);

                entity.Property(e => e.CCS_LmType).HasMaxLength(3);

                entity.Property(e => e.CHARGE_FOR)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CHARGE_FOR_ID).HasMaxLength(13);

                entity.Property(e => e.CHARGE_FOR_INFO).HasMaxLength(180);

                entity.Property(e => e.CLAIM_CCY).HasMaxLength(3);

                entity.Property(e => e.CLAIM_DATE).HasColumnType("datetime");

                entity.Property(e => e.CLAIM_REC_TPYE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.COLLECT_TYPE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CONFIRMATION)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.COUNTRY_CODE).HasMaxLength(2);

                entity.Property(e => e.COUNTRY_NAME).HasMaxLength(35);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.ClaimDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ConfirmFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ConfirmRefer).HasMaxLength(15);

                entity.Property(e => e.ConfirmType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DRAFT_AT).HasMaxLength(35);

                entity.Property(e => e.DateLastAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateToStop).HasColumnType("smalldatetime");

                entity.Property(e => e.Description).HasMaxLength(35);

                entity.Property(e => e.EVENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.EVENT_MODE).HasMaxLength(1);

                entity.Property(e => e.EVENT_TYPE).HasMaxLength(30);

                entity.Property(e => e.EXPIRY_DATE).HasColumnType("datetime");

                entity.Property(e => e.FLAG_TRANSFER)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FacNo).HasMaxLength(13);

                entity.Property(e => e.GENACC_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.GENACC_FLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IN_USE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ISSUE_BANK_CITY).HasMaxLength(35);

                entity.Property(e => e.ISSUE_BANK_ID).HasMaxLength(13);

                entity.Property(e => e.ISSUE_BANK_NAME).HasMaxLength(140);

                entity.Property(e => e.IntFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntRateCode).HasMaxLength(10);

                entity.Property(e => e.LC_BAL_CCY).HasMaxLength(3);

                entity.Property(e => e.LC_CURRENCY).HasMaxLength(3);

                entity.Property(e => e.LC_ISSUE_DATE).HasColumnType("datetime");

                entity.Property(e => e.LC_NO).HasMaxLength(35);

                entity.Property(e => e.LC_TYPE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastIntDate).HasColumnType("smalldatetime");

                entity.Property(e => e.METHOD).HasMaxLength(10);

                entity.Property(e => e.NOSTRO).HasMaxLength(19);

                entity.Property(e => e.NostroBank).HasMaxLength(14);

                entity.Property(e => e.PAYMENT_INSTRU)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PAY_REC_TYPE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PAY_REFUND)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PLACE_OF_EXPIRY).HasMaxLength(35);

                entity.Property(e => e.PREV_EXPIRY).HasColumnType("datetime");

                entity.Property(e => e.PastDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.REASON_OF_CANCEL).HasMaxLength(140);

                entity.Property(e => e.RECEIPT_NO).HasMaxLength(15);

                entity.Property(e => e.REIM_BK_ID).HasMaxLength(13);

                entity.Property(e => e.REIM_BK_NAME).HasMaxLength(35);

                entity.Property(e => e.REMARK).HasMaxLength(140);

                entity.Property(e => e.SENDING_BANK_ID).HasMaxLength(13);

                entity.Property(e => e.SENDING_BANK_INFO).HasMaxLength(180);

                entity.Property(e => e.SENDING_BANK_REF).HasMaxLength(35);

                entity.Property(e => e.SHIPMENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.SwifInID).HasMaxLength(50);

                entity.Property(e => e.SwiftMT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TENOR_DES).HasMaxLength(35);

                entity.Property(e => e.TENOR_TYPE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TRANFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TRANSACTION_TYPE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TRANSFER_DATE).HasColumnType("datetime");

                entity.Property(e => e.TRANSFER_EXPIRY_DATE).HasColumnType("datetime");

                entity.Property(e => e.TRANSFER_ID).HasMaxLength(13);

                entity.Property(e => e.TRANSFER_INFO).HasMaxLength(180);

                entity.Property(e => e.TRANSFER_SHIPMENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.TYPE_OF_CHARGE_TRANSFER).HasMaxLength(15);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.USER_ID).HasMaxLength(12);

                entity.Property(e => e.VOUCH_ID).HasMaxLength(35);

                entity.Property(e => e.ValueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.subStation_doc)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<pExadSWIn>(entity =>
            {
                entity.HasKey(e => e.SwifInID);

                entity.ToTable("pExadSWIn");

                entity.Property(e => e.SwifInID).HasMaxLength(50);

                entity.Property(e => e.AdviseDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Appicant).HasMaxLength(150);

                entity.Property(e => e.BenName).HasMaxLength(150);

                entity.Property(e => e.ExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ExpiryPlace).HasMaxLength(50);

                entity.Property(e => e.GoodsDesc).HasMaxLength(60);

                entity.Property(e => e.IssueBank).HasMaxLength(14);

                entity.Property(e => e.IssueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.IssueName).HasMaxLength(148);

                entity.Property(e => e.LCCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LCFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LCNo).HasMaxLength(20);

                entity.Property(e => e.MTType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ShipDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pExbc>(entity =>
            {
                entity.HasKey(e => new { e.RECORD_TYPE, e.REC_STATUS, e.EVENT_NO, e.EXPORT_BC_NO });

                entity.ToTable("pExbc");

                entity.Property(e => e.RECORD_TYPE).HasMaxLength(10);

                entity.Property(e => e.REC_STATUS).HasMaxLength(10);

                entity.Property(e => e.EXPORT_BC_NO).HasMaxLength(15);

                entity.Property(e => e.ACBAHTNET).HasMaxLength(15);

                entity.Property(e => e.ADJUST_LC_REF).HasMaxLength(50);

                entity.Property(e => e.ADJUST_TENOR).HasMaxLength(50);

                entity.Property(e => e.ADVICE_FORMAT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ADVICE_ISSUE_BANK)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AGENT_BANK_ID).HasMaxLength(13);

                entity.Property(e => e.AGENT_BANK_INFO).HasMaxLength(144);

                entity.Property(e => e.AGENT_BANK_NOSTRO).HasMaxLength(25);

                entity.Property(e => e.AGENT_BANK_REF).HasMaxLength(35);

                entity.Property(e => e.ALLOCATION).HasMaxLength(15);

                entity.Property(e => e.APPVNO).HasMaxLength(15);

                entity.Property(e => e.AUTH_CODE).HasMaxLength(12);

                entity.Property(e => e.AUTH_DATE).HasColumnType("datetime");

                entity.Property(e => e.AUTOOVERDUE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.BCPastDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BENE_ID).HasMaxLength(13);

                entity.Property(e => e.BENE_INFO)
                    .HasMaxLength(140)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BPOFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BUSINESS_TYPE).HasMaxLength(4);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(20);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(20);

                entity.Property(e => e.CCS_LmType).HasMaxLength(3);

                entity.Property(e => e.CFRRate).HasMaxLength(20);

                entity.Property(e => e.CHARGE_ACC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CLAIM_FORMAT).HasMaxLength(5);

                entity.Property(e => e.CNTY_CODE).HasMaxLength(2);

                entity.Property(e => e.COLLECT_REFUND)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.COMFIRM_DUE).HasColumnType("smalldatetime");

                entity.Property(e => e.CONFIRM_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.COVERING_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.COVERING_FOR).HasMaxLength(50);

                entity.Property(e => e.CREDIT_CURRENCY).HasMaxLength(3);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.Cust_AO).HasMaxLength(5);

                entity.Property(e => e.Cust_LO).HasMaxLength(8);

                entity.Property(e => e.DATELASTACCRU).HasColumnType("smalldatetime");

                entity.Property(e => e.DISCREPANCY_TYPE).HasMaxLength(10);

                entity.Property(e => e.DMS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DOCUMENT_COPY)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DRAFT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DRAFT_CCY).HasMaxLength(3);

                entity.Property(e => e.DRAWEE_INFO).HasMaxLength(175);

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateToStop).HasColumnType("smalldatetime");

                entity.Property(e => e.EVENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.EVENT_MODE).HasMaxLength(1);

                entity.Property(e => e.EVENT_TYPE).HasMaxLength(25);

                entity.Property(e => e.FACNO).HasMaxLength(13);

                entity.Property(e => e.FB_AMT).HasDefaultValueSql("((0))");

                entity.Property(e => e.FB_AMT_THB).HasDefaultValueSql("((0))");

                entity.Property(e => e.FB_CURRENCY).HasMaxLength(3);

                entity.Property(e => e.FB_RATE).HasDefaultValueSql("((0))");

                entity.Property(e => e.FORWARD_CONRACT_NO).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO1).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO2).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO3).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO4).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO5).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO6).HasMaxLength(15);

                entity.Property(e => e.FlagBack)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.GENACC_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.GENACC_FLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.GOOD_CODE).HasMaxLength(4);

                entity.Property(e => e.INTCODE)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.INTFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.INVOICE).HasMaxLength(70);

                entity.Property(e => e.ISSUE_BANK_ID).HasMaxLength(13);

                entity.Property(e => e.ISSUE_BANK_INFO).HasMaxLength(144);

                entity.Property(e => e.IntRateCode).HasMaxLength(10);

                entity.Property(e => e.LASTINTDATE).HasColumnType("smalldatetime");

                entity.Property(e => e.LCOVERDUE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LC_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.METHOD).HasMaxLength(10);

                entity.Property(e => e.MT202)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NARRATIVE).HasMaxLength(2100);

                entity.Property(e => e.ObjectType).HasMaxLength(6);

                entity.Property(e => e.PASTDUEDATE).HasColumnType("smalldatetime");

                entity.Property(e => e.PASTDUEFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PAYMENTTYPE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PAYMENT_INSTRC).HasMaxLength(1000);

                entity.Property(e => e.PAYMENT_INSTRU).HasMaxLength(10);

                entity.Property(e => e.PLUS_MINUS_DISC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PURCH_DISC_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.ParTnor_Type1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ParTnor_Type2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ParTnor_Type3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ParTnor_Type4)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ParTnor_Type5)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ParTnor_Type6)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PurposeCode).HasMaxLength(6);

                entity.Property(e => e.RECEIVED_NO).HasMaxLength(15);

                entity.Property(e => e.REFER_BC_NO).HasMaxLength(15);

                entity.Property(e => e.REIMBURSE_BANK_ID).HasMaxLength(13);

                entity.Property(e => e.REIMBURSE_BANK_INFO).HasMaxLength(140);

                entity.Property(e => e.RELETE_PACK).HasMaxLength(15);

                entity.Property(e => e.REL_CODE).HasMaxLength(6);

                entity.Property(e => e.REMIT_CLAIM_TYPE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RESTRICT_FR_BK_ADDR1).HasMaxLength(35);

                entity.Property(e => e.RESTRICT_FR_BK_ADDR2).HasMaxLength(35);

                entity.Property(e => e.RESTRICT_FR_BK_ADDR3).HasMaxLength(35);

                entity.Property(e => e.RESTRICT_FR_BK_NAME).HasMaxLength(35);

                entity.Property(e => e.RESTRICT_REFER).HasMaxLength(50);

                entity.Property(e => e.RESTRICT_TO_BK_ADDR1).HasMaxLength(35);

                entity.Property(e => e.RESTRICT_TO_BK_ADDR2).HasMaxLength(35);

                entity.Property(e => e.RESTRICT_TO_BK_ADDR3).HasMaxLength(35);

                entity.Property(e => e.RESTRICT_TO_BK_NAME).HasMaxLength(35);

                entity.Property(e => e.SIGHT_DUE_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.SIGHT_START_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.SWIFT_BANK).HasMaxLength(5);

                entity.Property(e => e.SWIFT_DISC).HasMaxLength(800);

                entity.Property(e => e.SWIFT_MAIL).HasMaxLength(500);

                entity.Property(e => e.TENOR_DAY_DESC).HasMaxLength(50);

                entity.Property(e => e.TERM_DUE_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.TERM_START_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.THIRD_BANK_ID).HasMaxLength(13);

                entity.Property(e => e.THIRD_BANK_INFO).HasMaxLength(144);

                entity.Property(e => e.TXTDOCUMENT).HasMaxLength(1000);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.USER_ID).HasMaxLength(12);

                entity.Property(e => e.UnderlyName).HasMaxLength(250);

                entity.Property(e => e.VALUE_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.VOUCH_ID).HasMaxLength(50);

                entity.Property(e => e.ValueDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pExchange>(entity =>
            {
                entity.HasKey(e => new { e.Exch_Date, e.Exch_Time, e.Exch_Ccy });

                entity.ToTable("pExchange");

                entity.Property(e => e.Exch_Date).HasColumnType("smalldatetime");

                entity.Property(e => e.Exch_Time)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Exch_Ccy).HasMaxLength(3);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("datetime");

                entity.Property(e => e.Exch_BNBuy).HasDefaultValueSql("((0))");

                entity.Property(e => e.Exch_BNSell).HasDefaultValueSql("((0))");

                entity.Property(e => e.Exch_TRate1).HasDefaultValueSql("((0))");

                entity.Property(e => e.Exch_TRate2).HasDefaultValueSql("((0))");

                entity.Property(e => e.Exch_TRate3).HasDefaultValueSql("((0))");

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<pExdoc>(entity =>
            {
                entity.HasKey(e => new { e.EXLC_NO, e.SEQNO, e.EVENT_NO });

                entity.ToTable("pExdoc");

                entity.Property(e => e.EXLC_NO).HasMaxLength(15);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.DOCUMENT_ID).HasMaxLength(25);

                entity.Property(e => e.DOCUMENT_NAME).HasMaxLength(50);

                entity.Property(e => e.EVENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.FMail_No).HasMaxLength(20);

                entity.Property(e => e.MODULE_TYPE).HasMaxLength(4);

                entity.Property(e => e.SMail_No).HasMaxLength(20);
            });

            modelBuilder.Entity<pExlc>(entity =>
            {
                entity.HasKey(e => new { e.RECORD_TYPE, e.REC_STATUS, e.EVENT_NO, e.EXPORT_LC_NO });

                entity.ToTable("pExlc");

                entity.Property(e => e.RECORD_TYPE).HasMaxLength(10);

                entity.Property(e => e.REC_STATUS).HasMaxLength(10);

                entity.Property(e => e.EXPORT_LC_NO).HasMaxLength(15);

                entity.Property(e => e.ACBAHTNET).HasMaxLength(15);

                entity.Property(e => e.ADJUST_LC_REF).HasMaxLength(50);

                entity.Property(e => e.ADJUST_TENOR).HasMaxLength(50);

                entity.Property(e => e.ADVICE_FORMAT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ADVICE_ISSUE_BANK)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AGENT_BANK_ID).HasMaxLength(13);

                entity.Property(e => e.AGENT_BANK_INFO).HasMaxLength(144);

                entity.Property(e => e.AGENT_BANK_NOSTRO).HasMaxLength(25);

                entity.Property(e => e.AGENT_BANK_REF).HasMaxLength(35);

                entity.Property(e => e.ALLOCATION).HasMaxLength(15);

                entity.Property(e => e.APPLICANT_NAME).HasMaxLength(70);

                entity.Property(e => e.APPVNO).HasMaxLength(15);

                entity.Property(e => e.AUTH_CODE).HasMaxLength(12);

                entity.Property(e => e.AUTH_DATE).HasColumnType("datetime");

                entity.Property(e => e.AUTOOVERDUE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.AcceptDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AcceptFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BENE_ID).HasMaxLength(13);

                entity.Property(e => e.BENE_INFO)
                    .HasMaxLength(140)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BPOFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BUSINESS_TYPE).HasMaxLength(4);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(20);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(20);

                entity.Property(e => e.CCS_LmType).HasMaxLength(3);

                entity.Property(e => e.CFRRate).HasMaxLength(20);

                entity.Property(e => e.CHARGE_ACC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CLAIM_FORMAT).HasMaxLength(5);

                entity.Property(e => e.CNTY_CODE).HasMaxLength(2);

                entity.Property(e => e.COLLECT_REFUND)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.COMFIRM_DUE).HasColumnType("smalldatetime");

                entity.Property(e => e.CONFIRM_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.COVERING_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.COVERING_FOR).HasMaxLength(50);

                entity.Property(e => e.CREDIT_CURRENCY).HasMaxLength(3);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.ConfirmFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_AO).HasMaxLength(5);

                entity.Property(e => e.Cust_LO).HasMaxLength(8);

                entity.Property(e => e.DATELASTACCRU).HasColumnType("smalldatetime");

                entity.Property(e => e.DISCREPANCY_TYPE).HasMaxLength(10);

                entity.Property(e => e.DMS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DOCUMENT_COPY)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DRAFT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DRAFT_CCY).HasMaxLength(3);

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateToStop).HasColumnType("smalldatetime");

                entity.Property(e => e.EVENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.EVENT_MODE).HasMaxLength(1);

                entity.Property(e => e.EVENT_TYPE).HasMaxLength(25);

                entity.Property(e => e.FACNO).HasMaxLength(13);

                entity.Property(e => e.FB_AMT).HasDefaultValueSql("((0))");

                entity.Property(e => e.FB_AMT_THB).HasDefaultValueSql("((0))");

                entity.Property(e => e.FB_CURRENCY).HasMaxLength(3);

                entity.Property(e => e.FB_RATE).HasDefaultValueSql("((0))");

                entity.Property(e => e.FORWARD_CONRACT_NO).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO1).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO2).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO3).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO4).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO5).HasMaxLength(15);

                entity.Property(e => e.FORWARD_CONRACT_NO6).HasMaxLength(15);

                entity.Property(e => e.FlagBack)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.GENACC_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.GENACC_FLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.GOOD_CODE).HasMaxLength(4);

                entity.Property(e => e.INTCODE)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.INTFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.INVOICE).HasMaxLength(70);

                entity.Property(e => e.ISSUE_BANK_ID).HasMaxLength(13);

                entity.Property(e => e.ISSUE_BANK_INFO).HasMaxLength(144);

                entity.Property(e => e.IntRateCode).HasMaxLength(10);

                entity.Property(e => e.LASTINTDATE).HasColumnType("smalldatetime");

                entity.Property(e => e.LCOVERDUE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LCPastDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LC_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.LC_REF_NO).HasMaxLength(35);

                entity.Property(e => e.METHOD).HasMaxLength(10);

                entity.Property(e => e.MT202)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NARRATIVE).HasMaxLength(2100);

                entity.Property(e => e.ObjectType).HasMaxLength(6);

                entity.Property(e => e.PASTDUEDATE).HasColumnType("smalldatetime");

                entity.Property(e => e.PASTDUEFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PAYMENTTYPE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PAYMENT_INSTRC).HasMaxLength(1000);

                entity.Property(e => e.PAYMENT_INSTRU).HasMaxLength(10);

                entity.Property(e => e.PLUS_MINUS_DISC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PURCH_DISC_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.ParTnor_Type1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ParTnor_Type2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ParTnor_Type3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ParTnor_Type4)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ParTnor_Type5)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ParTnor_Type6)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PurposeCode).HasMaxLength(6);

                entity.Property(e => e.RECEIVED_NO).HasMaxLength(15);

                entity.Property(e => e.REFER_LC_NO).HasMaxLength(15);

                entity.Property(e => e.REIMBURSE_BANK_ID).HasMaxLength(13);

                entity.Property(e => e.REIMBURSE_BANK_INFO).HasMaxLength(140);

                entity.Property(e => e.RELETE_CONFIRM).HasMaxLength(15);

                entity.Property(e => e.RELETE_PACK).HasMaxLength(15);

                entity.Property(e => e.REL_CODE).HasMaxLength(6);

                entity.Property(e => e.REMIT_CLAIM_TYPE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RESTRICT_FR_BK_ADDR1).HasMaxLength(35);

                entity.Property(e => e.RESTRICT_FR_BK_ADDR2).HasMaxLength(35);

                entity.Property(e => e.RESTRICT_FR_BK_ADDR3).HasMaxLength(35);

                entity.Property(e => e.RESTRICT_FR_BK_NAME).HasMaxLength(35);

                entity.Property(e => e.RESTRICT_REFER).HasMaxLength(50);

                entity.Property(e => e.RESTRICT_TO_BK_ADDR1).HasMaxLength(35);

                entity.Property(e => e.RESTRICT_TO_BK_ADDR2).HasMaxLength(35);

                entity.Property(e => e.RESTRICT_TO_BK_ADDR3).HasMaxLength(35);

                entity.Property(e => e.RESTRICT_TO_BK_NAME).HasMaxLength(35);

                entity.Property(e => e.SIGHT_DUE_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.SIGHT_START_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.SWIFT_BANK).HasMaxLength(5);

                entity.Property(e => e.SWIFT_DISC).HasMaxLength(800);

                entity.Property(e => e.SWIFT_MAIL).HasMaxLength(500);

                entity.Property(e => e.TENOR_DAY_DESC).HasMaxLength(50);

                entity.Property(e => e.TERM_DUE_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.TERM_START_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.THIRD_BANK_ID).HasMaxLength(13);

                entity.Property(e => e.THIRD_BANK_INFO).HasMaxLength(144);

                entity.Property(e => e.TXTDOCUMENT).HasMaxLength(1000);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.USER_ID).HasMaxLength(12);

                entity.Property(e => e.UnderlyName).HasMaxLength(250);

                entity.Property(e => e.VALUE_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.VOUCH_ID).HasMaxLength(50);

                entity.Property(e => e.ValueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.WOFUND)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.WithOut)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.WithOutFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.WithOutType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Wref_Bank_ID).HasMaxLength(14);

                entity.Property(e => e.applicant_info).HasMaxLength(240);
            });

            modelBuilder.Entity<pExpc>(entity =>
            {
                entity.HasKey(e => new { e.PACKING_NO, e.record_type, e.event_no });

                entity.ToTable("pExpc");

                entity.Property(e => e.PACKING_NO).HasMaxLength(15);

                entity.Property(e => e.record_type).HasMaxLength(10);

                entity.Property(e => e.ALLOCATION).HasMaxLength(15);

                entity.Property(e => e.AcBahtnet).HasMaxLength(15);

                entity.Property(e => e.ApproveBorad)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AppvNo).HasMaxLength(15);

                entity.Property(e => e.AutoOverdue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Y')")
                    .IsFixedLength(true);

                entity.Property(e => e.BPOFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(20);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(20);

                entity.Property(e => e.CCS_LmType).HasMaxLength(3);

                entity.Property(e => e.CFRRate).HasMaxLength(20);

                entity.Property(e => e.CalIntDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.DMS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DateLastAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateToStop).HasColumnType("smalldatetime");

                entity.Property(e => e.FACNO).HasMaxLength(15);

                entity.Property(e => e.FcdAcc).HasMaxLength(15);

                entity.Property(e => e.FixDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FlagAmend)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FlagBack)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FlagSettle)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntRateCode).HasMaxLength(10);

                entity.Property(e => e.LastIntDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LastPayDate).HasColumnType("smalldatetime");

                entity.Property(e => e.OINTCODE).HasMaxLength(10);

                entity.Property(e => e.ObjectType).HasMaxLength(6);

                entity.Property(e => e.OrderFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PCOverdue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PCPastDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PackNote).HasMaxLength(70);

                entity.Property(e => e.PastDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PastDueFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PcIntType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Pre_pack_ccy).HasDefaultValueSql("((0))");

                entity.Property(e => e.Pre_pack_thb).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurposeCode).HasMaxLength(6);

                entity.Property(e => e.REFUNDTAX).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivePayBy).HasMaxLength(50);

                entity.Property(e => e.Rel_code).HasMaxLength(6);

                entity.Property(e => e.TaxRefund)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UnderlyName).HasMaxLength(250);

                entity.Property(e => e.VALUE_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.ValueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.applicant_name).HasMaxLength(70);

                entity.Property(e => e.auth_code).HasMaxLength(12);

                entity.Property(e => e.auth_date).HasColumnType("smalldatetime");

                entity.Property(e => e.business_type).HasMaxLength(4);

                entity.Property(e => e.cnty_code).HasMaxLength(2);

                entity.Property(e => e.contra_date).HasColumnType("smalldatetime");

                entity.Property(e => e.current_60_daydue).HasColumnType("smalldatetime");

                entity.Property(e => e.current_pc_due).HasColumnType("smalldatetime");

                entity.Property(e => e.cust_id).HasMaxLength(13);

                entity.Property(e => e.cust_info).HasMaxLength(170);

                entity.Property(e => e.doc_ccy).HasMaxLength(3);

                entity.Property(e => e.doc_expiry_date).HasColumnType("smalldatetime");

                entity.Property(e => e.event_date).HasColumnType("smalldatetime");

                entity.Property(e => e.event_mode).HasMaxLength(1);

                entity.Property(e => e.event_type).HasMaxLength(25);

                entity.Property(e => e.forward_contract1).HasMaxLength(20);

                entity.Property(e => e.forward_contract2).HasMaxLength(20);

                entity.Property(e => e.forward_contract3).HasMaxLength(20);

                entity.Property(e => e.forward_contract4).HasMaxLength(20);

                entity.Property(e => e.forward_contract5).HasMaxLength(20);

                entity.Property(e => e.forward_contract6).HasMaxLength(20);

                entity.Property(e => e.forward_contract7).HasMaxLength(20);

                entity.Property(e => e.forward_contract8).HasMaxLength(20);

                entity.Property(e => e.forward_contract9).HasMaxLength(20);

                entity.Property(e => e.genacc_date).HasColumnType("smalldatetime");

                entity.Property(e => e.genacc_flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.good_code).HasMaxLength(3);

                entity.Property(e => e.good_desc).HasMaxLength(200);

                entity.Property(e => e.in_Use)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.method).HasMaxLength(10);

                entity.Property(e => e.new_pn_no).HasMaxLength(20);

                entity.Property(e => e.pack_under).HasMaxLength(35);

                entity.Property(e => e.packing_for).HasMaxLength(3);

                entity.Property(e => e.partial_full_rate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.pay_instruc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.pay_method)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.pay_rec_type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.pc_start_date).HasColumnType("smalldatetime");

                entity.Property(e => e.pn_no).HasMaxLength(20);

                entity.Property(e => e.prev_start_date).HasColumnType("smalldatetime");

                entity.Property(e => e.rec_status).HasMaxLength(10);

                entity.Property(e => e.received_no).HasMaxLength(15);

                entity.Property(e => e.refer_lcno).HasMaxLength(20);

                entity.Property(e => e.remark).HasMaxLength(2100);

                entity.Property(e => e.shipmentFr).HasMaxLength(70);

                entity.Property(e => e.shipmentTo).HasMaxLength(70);

                entity.Property(e => e.update_date).HasColumnType("smalldatetime");

                entity.Property(e => e.user_id).HasMaxLength(12);

                entity.Property(e => e.vouch_id).HasMaxLength(35);
            });

            modelBuilder.Entity<pExpc2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pExpc2");

                entity.Property(e => e.ALLOCATION).HasMaxLength(255);

                entity.Property(e => e.AcBahtnet).HasMaxLength(255);

                entity.Property(e => e.AccruAmt).HasMaxLength(255);

                entity.Property(e => e.AccruCcy).HasMaxLength(255);

                entity.Property(e => e.AccruPending).HasMaxLength(255);

                entity.Property(e => e.Amend_no).HasMaxLength(255);

                entity.Property(e => e.ApproveBorad).HasMaxLength(255);

                entity.Property(e => e.AppvNo).HasMaxLength(255);

                entity.Property(e => e.AutoOverdue).HasMaxLength(255);

                entity.Property(e => e.BPOFlag).HasMaxLength(255);

                entity.Property(e => e.BahtNet).HasMaxLength(255);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(255);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(255);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(255);

                entity.Property(e => e.CCS_LmType).HasMaxLength(255);

                entity.Property(e => e.CFRRate).HasMaxLength(255);

                entity.Property(e => e.CalIntDate).HasMaxLength(255);

                entity.Property(e => e.Campaign_Code).HasMaxLength(255);

                entity.Property(e => e.Campaign_EffDate).HasMaxLength(255);

                entity.Property(e => e.CenterID).HasMaxLength(255);

                entity.Property(e => e.Com_Lieu).HasMaxLength(255);

                entity.Property(e => e.Comm_Certi).HasMaxLength(255);

                entity.Property(e => e.DAccruAmt).HasMaxLength(255);

                entity.Property(e => e.DMS).HasMaxLength(255);

                entity.Property(e => e.DateLastAccru).HasMaxLength(255);

                entity.Property(e => e.DateStartAccru).HasMaxLength(255);

                entity.Property(e => e.DateToStop).HasMaxLength(255);

                entity.Property(e => e.Due_no).HasMaxLength(255);

                entity.Property(e => e.FACNO).HasMaxLength(255);

                entity.Property(e => e.FcdAcc).HasMaxLength(255);

                entity.Property(e => e.FcdAmt).HasMaxLength(255);

                entity.Property(e => e.FixDate).HasMaxLength(255);

                entity.Property(e => e.FlagAmend).HasMaxLength(255);

                entity.Property(e => e.FlagBack).HasMaxLength(255);

                entity.Property(e => e.FlagSettle).HasMaxLength(255);

                entity.Property(e => e.FrontFee).HasMaxLength(255);

                entity.Property(e => e.IntBalance).HasMaxLength(255);

                entity.Property(e => e.IntBaseDay).HasMaxLength(255);

                entity.Property(e => e.IntFlag).HasMaxLength(255);

                entity.Property(e => e.IntRateCode).HasMaxLength(255);

                entity.Property(e => e.IntReceived).HasMaxLength(255);

                entity.Property(e => e.LastAccruAmt).HasMaxLength(255);

                entity.Property(e => e.LastAccruCcy).HasMaxLength(255);

                entity.Property(e => e.LastIntAmt).HasMaxLength(255);

                entity.Property(e => e.LastIntDate).HasMaxLength(255);

                entity.Property(e => e.LastPayDate).HasMaxLength(255);

                entity.Property(e => e.LastPrnthb).HasMaxLength(255);

                entity.Property(e => e.MidRate).HasMaxLength(255);

                entity.Property(e => e.NewAccruAmt).HasMaxLength(255);

                entity.Property(e => e.NewAccruCcy).HasMaxLength(255);

                entity.Property(e => e.OBASEDAY).HasMaxLength(255);

                entity.Property(e => e.OINTCODE).HasMaxLength(255);

                entity.Property(e => e.OINTCURRATE).HasMaxLength(255);

                entity.Property(e => e.OINTDAY).HasMaxLength(255);

                entity.Property(e => e.OINTRATE).HasMaxLength(255);

                entity.Property(e => e.OINTSPDRATE).HasMaxLength(255);

                entity.Property(e => e.ObjectType).HasMaxLength(255);

                entity.Property(e => e.OrderFlag).HasMaxLength(255);

                entity.Property(e => e.OveSeqno).HasMaxLength(255);

                entity.Property(e => e.PACKING_NO).HasMaxLength(255);

                entity.Property(e => e.PAccruAmt).HasMaxLength(255);

                entity.Property(e => e.PCOverdue).HasMaxLength(255);

                entity.Property(e => e.PCPastDue).HasMaxLength(255);

                entity.Property(e => e.PCProfit).HasMaxLength(255);

                entity.Property(e => e.PackNote).HasMaxLength(255);

                entity.Property(e => e.PastDueDate).HasMaxLength(255);

                entity.Property(e => e.PastDueFlag).HasMaxLength(255);

                entity.Property(e => e.PayNo).HasMaxLength(255);

                entity.Property(e => e.PaymentType).HasMaxLength(255);

                entity.Property(e => e.PcIntType).HasMaxLength(255);

                entity.Property(e => e.Pre_pack_ccy).HasMaxLength(255);

                entity.Property(e => e.Pre_pack_thb).HasMaxLength(255);

                entity.Property(e => e.PrnBalance).HasMaxLength(255);

                entity.Property(e => e.PurposeCode).HasMaxLength(255);

                entity.Property(e => e.REFUNDTAX).HasMaxLength(255);

                entity.Property(e => e.ReceivePayBy).HasMaxLength(255);

                entity.Property(e => e.Rel_code).HasMaxLength(255);

                entity.Property(e => e.RevAccru).HasMaxLength(255);

                entity.Property(e => e.RevAccruTax).HasMaxLength(255);

                entity.Property(e => e.SuspAmt).HasMaxLength(255);

                entity.Property(e => e.SuspBht).HasMaxLength(255);

                entity.Property(e => e.TaxRefund).HasMaxLength(255);

                entity.Property(e => e.TotalAccruAmt).HasMaxLength(255);

                entity.Property(e => e.TotalAccruBht).HasMaxLength(255);

                entity.Property(e => e.TotalSuspAmt).HasMaxLength(255);

                entity.Property(e => e.TotalSuspBht).HasMaxLength(255);

                entity.Property(e => e.UnderlyName).HasMaxLength(255);

                entity.Property(e => e.VALUE_DATE).HasMaxLength(255);

                entity.Property(e => e.ValueDate).HasMaxLength(255);

                entity.Property(e => e.applicant_name).HasMaxLength(255);

                entity.Property(e => e.auth_code).HasMaxLength(255);

                entity.Property(e => e.auth_date).HasMaxLength(255);

                entity.Property(e => e.business_type).HasMaxLength(255);

                entity.Property(e => e.cnty_code).HasMaxLength(255);

                entity.Property(e => e.comm_OnTT).HasMaxLength(255);

                entity.Property(e => e.comm_other).HasMaxLength(255);

                entity.Property(e => e.contra_bal).HasMaxLength(255);

                entity.Property(e => e.contra_date).HasMaxLength(255);

                entity.Property(e => e.current_60_daydue).HasMaxLength(255);

                entity.Property(e => e.current_intrate).HasMaxLength(255);

                entity.Property(e => e.current_pc_due).HasMaxLength(255);

                entity.Property(e => e.cust_id).HasMaxLength(255);

                entity.Property(e => e.deduct_export_thb).HasMaxLength(255);

                entity.Property(e => e.doc_amount).HasMaxLength(255);

                entity.Property(e => e.doc_ccy).HasMaxLength(255);

                entity.Property(e => e.doc_expiry_date).HasMaxLength(255);

                entity.Property(e => e.duty_stamp).HasMaxLength(255);

                entity.Property(e => e.event_date).HasMaxLength(255);

                entity.Property(e => e.event_mode).HasMaxLength(255);

                entity.Property(e => e.event_no).HasMaxLength(255);

                entity.Property(e => e.event_type).HasMaxLength(255);

                entity.Property(e => e.exch_rate).HasMaxLength(255);

                entity.Property(e => e.exch_rate1).HasMaxLength(255);

                entity.Property(e => e.exch_rate2).HasMaxLength(255);

                entity.Property(e => e.exch_rate3).HasMaxLength(255);

                entity.Property(e => e.exch_rate4).HasMaxLength(255);

                entity.Property(e => e.exch_rate5).HasMaxLength(255);

                entity.Property(e => e.exch_rate6).HasMaxLength(255);

                entity.Property(e => e.exch_rate7).HasMaxLength(255);

                entity.Property(e => e.exch_rate8).HasMaxLength(255);

                entity.Property(e => e.exch_rate9).HasMaxLength(255);

                entity.Property(e => e.forward_contract1).HasMaxLength(255);

                entity.Property(e => e.forward_contract2).HasMaxLength(255);

                entity.Property(e => e.forward_contract3).HasMaxLength(255);

                entity.Property(e => e.forward_contract4).HasMaxLength(255);

                entity.Property(e => e.forward_contract5).HasMaxLength(255);

                entity.Property(e => e.forward_contract6).HasMaxLength(255);

                entity.Property(e => e.forward_contract7).HasMaxLength(255);

                entity.Property(e => e.forward_contract8).HasMaxLength(255);

                entity.Property(e => e.forward_contract9).HasMaxLength(255);

                entity.Property(e => e.genacc_date).HasMaxLength(255);

                entity.Property(e => e.genacc_flag).HasMaxLength(255);

                entity.Property(e => e.good_code).HasMaxLength(255);

                entity.Property(e => e.handling_Fee).HasMaxLength(255);

                entity.Property(e => e.in_Use).HasMaxLength(255);

                entity.Property(e => e.interest_ccy1).HasMaxLength(255);

                entity.Property(e => e.interest_ccy2).HasMaxLength(255);

                entity.Property(e => e.interest_thb1).HasMaxLength(255);

                entity.Property(e => e.interest_thb2).HasMaxLength(255);

                entity.Property(e => e.method).HasMaxLength(255);

                entity.Property(e => e.new_pn_no).HasMaxLength(255);

                entity.Property(e => e.other_no).HasMaxLength(255);

                entity.Property(e => e.pack_ccy).HasMaxLength(255);

                entity.Property(e => e.pack_thb).HasMaxLength(255);

                entity.Property(e => e.pack_under).HasMaxLength(255);

                entity.Property(e => e.packing_for).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy1).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy2).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy3).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy4).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy5).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy6).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy7).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy8).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy9).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb1).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb2).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb3).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb4).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb5).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb6).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb7).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb8).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb9).HasMaxLength(255);

                entity.Property(e => e.partial_full_rate).HasMaxLength(255);

                entity.Property(e => e.pay_instruc).HasMaxLength(255);

                entity.Property(e => e.pay_method).HasMaxLength(255);

                entity.Property(e => e.pay_rec_type).HasMaxLength(255);

                entity.Property(e => e.pc_int_rate).HasMaxLength(255);

                entity.Property(e => e.pc_start_date).HasMaxLength(255);

                entity.Property(e => e.penalty_amt).HasMaxLength(255);

                entity.Property(e => e.pn_no).HasMaxLength(255);

                entity.Property(e => e.prev_contra_bal).HasMaxLength(255);

                entity.Property(e => e.prev_start_date).HasMaxLength(255);

                entity.Property(e => e.principle_amt_ccy1).HasMaxLength(255);

                entity.Property(e => e.principle_amt_ccy2).HasMaxLength(255);

                entity.Property(e => e.principle_amt_ccy3).HasMaxLength(255);

                entity.Property(e => e.principle_amt_ccy4).HasMaxLength(255);

                entity.Property(e => e.principle_amt_thb1).HasMaxLength(255);

                entity.Property(e => e.principle_amt_thb2).HasMaxLength(255);

                entity.Property(e => e.principle_amt_thb3).HasMaxLength(255);

                entity.Property(e => e.principle_amt_thb4).HasMaxLength(255);

                entity.Property(e => e.principle_amt_thb5).HasMaxLength(255);

                entity.Property(e => e.rate).HasMaxLength(255);

                entity.Property(e => e.rec_status).HasMaxLength(255);

                entity.Property(e => e.received_no).HasMaxLength(255);

                entity.Property(e => e.record_type).HasMaxLength(255);

                entity.Property(e => e.refer_lcno).HasMaxLength(255);

                entity.Property(e => e.refund_tax_amt).HasMaxLength(255);

                entity.Property(e => e.remark).HasMaxLength(255);

                entity.Property(e => e.shipmentFr).HasMaxLength(255);

                entity.Property(e => e.shipmentTo).HasMaxLength(255);

                entity.Property(e => e.spread_rate).HasMaxLength(255);

                entity.Property(e => e.tot_pc_day).HasMaxLength(255);

                entity.Property(e => e.total_amount).HasMaxLength(255);

                entity.Property(e => e.total_bal_ccy).HasMaxLength(255);

                entity.Property(e => e.total_bal_thb).HasMaxLength(255);

                entity.Property(e => e.total_charge).HasMaxLength(255);

                entity.Property(e => e.total_credit_ac).HasMaxLength(255);

                entity.Property(e => e.total_date).HasMaxLength(255);

                entity.Property(e => e.update_date).HasMaxLength(255);

                entity.Property(e => e.user_id).HasMaxLength(255);

                entity.Property(e => e.vouch_id).HasMaxLength(255);

                entity.Property(e => e.xxxx).HasMaxLength(255);
            });

            modelBuilder.Entity<pExpc3>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pExpc3");

                entity.Property(e => e.ALLOCATION).HasMaxLength(255);

                entity.Property(e => e.AcBahtnet).HasMaxLength(255);

                entity.Property(e => e.AccruAmt).HasMaxLength(255);

                entity.Property(e => e.AccruCcy).HasMaxLength(255);

                entity.Property(e => e.AccruPending).HasMaxLength(255);

                entity.Property(e => e.Amend_no).HasMaxLength(255);

                entity.Property(e => e.ApproveBorad).HasMaxLength(255);

                entity.Property(e => e.AppvNo).HasMaxLength(255);

                entity.Property(e => e.AutoOverdue).HasMaxLength(255);

                entity.Property(e => e.BPOFlag).HasMaxLength(255);

                entity.Property(e => e.BahtNet).HasMaxLength(255);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(255);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(255);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(255);

                entity.Property(e => e.CCS_LmType).HasMaxLength(255);

                entity.Property(e => e.CFRRate).HasMaxLength(255);

                entity.Property(e => e.CalIntDate).HasMaxLength(255);

                entity.Property(e => e.Campaign_Code).HasMaxLength(255);

                entity.Property(e => e.Campaign_EffDate).HasMaxLength(255);

                entity.Property(e => e.CenterID).HasMaxLength(255);

                entity.Property(e => e.Com_Lieu).HasMaxLength(255);

                entity.Property(e => e.Comm_Certi).HasMaxLength(255);

                entity.Property(e => e.DAccruAmt).HasMaxLength(255);

                entity.Property(e => e.DMS).HasMaxLength(255);

                entity.Property(e => e.DateLastAccru).HasMaxLength(255);

                entity.Property(e => e.DateStartAccru).HasMaxLength(255);

                entity.Property(e => e.DateToStop).HasMaxLength(255);

                entity.Property(e => e.Due_no).HasMaxLength(255);

                entity.Property(e => e.FACNO).HasMaxLength(255);

                entity.Property(e => e.FcdAcc).HasMaxLength(255);

                entity.Property(e => e.FcdAmt).HasMaxLength(255);

                entity.Property(e => e.FixDate).HasMaxLength(255);

                entity.Property(e => e.FlagAmend).HasMaxLength(255);

                entity.Property(e => e.FlagBack).HasMaxLength(255);

                entity.Property(e => e.FlagSettle).HasMaxLength(255);

                entity.Property(e => e.FrontFee).HasMaxLength(255);

                entity.Property(e => e.IntBalance).HasMaxLength(255);

                entity.Property(e => e.IntBaseDay).HasMaxLength(255);

                entity.Property(e => e.IntFlag).HasMaxLength(255);

                entity.Property(e => e.IntRateCode).HasMaxLength(255);

                entity.Property(e => e.IntReceived).HasMaxLength(255);

                entity.Property(e => e.LastAccruAmt).HasMaxLength(255);

                entity.Property(e => e.LastAccruCcy).HasMaxLength(255);

                entity.Property(e => e.LastIntAmt).HasMaxLength(255);

                entity.Property(e => e.LastIntDate).HasMaxLength(255);

                entity.Property(e => e.LastPayDate).HasMaxLength(255);

                entity.Property(e => e.LastPrnthb).HasMaxLength(255);

                entity.Property(e => e.MidRate).HasMaxLength(255);

                entity.Property(e => e.NewAccruAmt).HasMaxLength(255);

                entity.Property(e => e.NewAccruCcy).HasMaxLength(255);

                entity.Property(e => e.OBASEDAY).HasMaxLength(255);

                entity.Property(e => e.OINTCODE).HasMaxLength(255);

                entity.Property(e => e.OINTCURRATE).HasMaxLength(255);

                entity.Property(e => e.OINTDAY).HasMaxLength(255);

                entity.Property(e => e.OINTRATE).HasMaxLength(255);

                entity.Property(e => e.OINTSPDRATE).HasMaxLength(255);

                entity.Property(e => e.ObjectType).HasMaxLength(255);

                entity.Property(e => e.OrderFlag).HasMaxLength(255);

                entity.Property(e => e.OveSeqno).HasMaxLength(255);

                entity.Property(e => e.PACKING_NO).HasMaxLength(255);

                entity.Property(e => e.PAccruAmt).HasMaxLength(255);

                entity.Property(e => e.PCOverdue).HasMaxLength(255);

                entity.Property(e => e.PCPastDue).HasMaxLength(255);

                entity.Property(e => e.PCProfit).HasMaxLength(255);

                entity.Property(e => e.PackNote).HasMaxLength(255);

                entity.Property(e => e.PastDueDate).HasMaxLength(255);

                entity.Property(e => e.PastDueFlag).HasMaxLength(255);

                entity.Property(e => e.PayNo).HasMaxLength(255);

                entity.Property(e => e.PaymentType).HasMaxLength(255);

                entity.Property(e => e.PcIntType).HasMaxLength(255);

                entity.Property(e => e.Pre_pack_ccy).HasMaxLength(255);

                entity.Property(e => e.Pre_pack_thb).HasMaxLength(255);

                entity.Property(e => e.PrnBalance).HasMaxLength(255);

                entity.Property(e => e.PurposeCode).HasMaxLength(255);

                entity.Property(e => e.REFUNDTAX).HasMaxLength(255);

                entity.Property(e => e.ReceivePayBy).HasMaxLength(255);

                entity.Property(e => e.Rel_code).HasMaxLength(255);

                entity.Property(e => e.RevAccru).HasMaxLength(255);

                entity.Property(e => e.RevAccruTax).HasMaxLength(255);

                entity.Property(e => e.SuspAmt).HasMaxLength(255);

                entity.Property(e => e.SuspBht).HasMaxLength(255);

                entity.Property(e => e.TaxRefund).HasMaxLength(255);

                entity.Property(e => e.TotalAccruAmt).HasMaxLength(255);

                entity.Property(e => e.TotalAccruBht).HasMaxLength(255);

                entity.Property(e => e.TotalSuspAmt).HasMaxLength(255);

                entity.Property(e => e.TotalSuspBht).HasMaxLength(255);

                entity.Property(e => e.UnderlyName).HasMaxLength(255);

                entity.Property(e => e.VALUE_DATE).HasMaxLength(255);

                entity.Property(e => e.ValueDate).HasMaxLength(255);

                entity.Property(e => e.applicant_name).HasMaxLength(255);

                entity.Property(e => e.auth_code).HasMaxLength(255);

                entity.Property(e => e.auth_date).HasMaxLength(255);

                entity.Property(e => e.business_type).HasMaxLength(255);

                entity.Property(e => e.cnty_code).HasMaxLength(255);

                entity.Property(e => e.comm_OnTT).HasMaxLength(255);

                entity.Property(e => e.comm_other).HasMaxLength(255);

                entity.Property(e => e.contra_bal).HasMaxLength(255);

                entity.Property(e => e.contra_date).HasMaxLength(255);

                entity.Property(e => e.current_60_daydue).HasMaxLength(255);

                entity.Property(e => e.current_intrate).HasMaxLength(255);

                entity.Property(e => e.current_pc_due).HasMaxLength(255);

                entity.Property(e => e.cust_id).HasMaxLength(255);

                entity.Property(e => e.cust_info).HasMaxLength(255);

                entity.Property(e => e.deduct_export_thb).HasMaxLength(255);

                entity.Property(e => e.doc_amount).HasMaxLength(255);

                entity.Property(e => e.doc_ccy).HasMaxLength(255);

                entity.Property(e => e.doc_expiry_date).HasMaxLength(255);

                entity.Property(e => e.duty_stamp).HasMaxLength(255);

                entity.Property(e => e.event_date).HasMaxLength(255);

                entity.Property(e => e.event_mode).HasMaxLength(255);

                entity.Property(e => e.event_no).HasMaxLength(255);

                entity.Property(e => e.event_type).HasMaxLength(255);

                entity.Property(e => e.exch_rate).HasMaxLength(255);

                entity.Property(e => e.exch_rate1).HasMaxLength(255);

                entity.Property(e => e.exch_rate2).HasMaxLength(255);

                entity.Property(e => e.exch_rate3).HasMaxLength(255);

                entity.Property(e => e.exch_rate4).HasMaxLength(255);

                entity.Property(e => e.exch_rate5).HasMaxLength(255);

                entity.Property(e => e.exch_rate6).HasMaxLength(255);

                entity.Property(e => e.exch_rate7).HasMaxLength(255);

                entity.Property(e => e.exch_rate8).HasMaxLength(255);

                entity.Property(e => e.exch_rate9).HasMaxLength(255);

                entity.Property(e => e.forward_contract1).HasMaxLength(255);

                entity.Property(e => e.forward_contract2).HasMaxLength(255);

                entity.Property(e => e.forward_contract3).HasMaxLength(255);

                entity.Property(e => e.forward_contract4).HasMaxLength(255);

                entity.Property(e => e.forward_contract5).HasMaxLength(255);

                entity.Property(e => e.forward_contract6).HasMaxLength(255);

                entity.Property(e => e.forward_contract7).HasMaxLength(255);

                entity.Property(e => e.forward_contract8).HasMaxLength(255);

                entity.Property(e => e.forward_contract9).HasMaxLength(255);

                entity.Property(e => e.genacc_date).HasMaxLength(255);

                entity.Property(e => e.genacc_flag).HasMaxLength(255);

                entity.Property(e => e.good_code).HasMaxLength(255);

                entity.Property(e => e.good_desc).HasMaxLength(255);

                entity.Property(e => e.handling_Fee).HasMaxLength(255);

                entity.Property(e => e.in_Use).HasMaxLength(255);

                entity.Property(e => e.interest_ccy1).HasMaxLength(255);

                entity.Property(e => e.interest_ccy2).HasMaxLength(255);

                entity.Property(e => e.interest_thb1).HasMaxLength(255);

                entity.Property(e => e.interest_thb2).HasMaxLength(255);

                entity.Property(e => e.method).HasMaxLength(255);

                entity.Property(e => e.new_pn_no).HasMaxLength(255);

                entity.Property(e => e.other_no).HasMaxLength(255);

                entity.Property(e => e.pack_ccy).HasMaxLength(255);

                entity.Property(e => e.pack_thb).HasMaxLength(255);

                entity.Property(e => e.pack_under).HasMaxLength(255);

                entity.Property(e => e.packing_for).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy1).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy2).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy3).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy4).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy5).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy6).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy7).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy8).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy9).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb1).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb2).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb3).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb4).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb5).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb6).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb7).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb8).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb9).HasMaxLength(255);

                entity.Property(e => e.partial_full_rate).HasMaxLength(255);

                entity.Property(e => e.pay_instruc).HasMaxLength(255);

                entity.Property(e => e.pay_method).HasMaxLength(255);

                entity.Property(e => e.pay_rec_type).HasMaxLength(255);

                entity.Property(e => e.pc_int_rate).HasMaxLength(255);

                entity.Property(e => e.pc_start_date).HasMaxLength(255);

                entity.Property(e => e.penalty_amt).HasMaxLength(255);

                entity.Property(e => e.pn_no).HasMaxLength(255);

                entity.Property(e => e.prev_contra_bal).HasMaxLength(255);

                entity.Property(e => e.prev_start_date).HasMaxLength(255);

                entity.Property(e => e.principle_amt_ccy1).HasMaxLength(255);

                entity.Property(e => e.principle_amt_ccy2).HasMaxLength(255);

                entity.Property(e => e.principle_amt_ccy3).HasMaxLength(255);

                entity.Property(e => e.principle_amt_ccy4).HasMaxLength(255);

                entity.Property(e => e.principle_amt_thb1).HasMaxLength(255);

                entity.Property(e => e.principle_amt_thb2).HasMaxLength(255);

                entity.Property(e => e.principle_amt_thb3).HasMaxLength(255);

                entity.Property(e => e.principle_amt_thb4).HasMaxLength(255);

                entity.Property(e => e.principle_amt_thb5).HasMaxLength(255);

                entity.Property(e => e.rate).HasMaxLength(255);

                entity.Property(e => e.rec_status).HasMaxLength(255);

                entity.Property(e => e.received_no).HasMaxLength(255);

                entity.Property(e => e.record_type).HasMaxLength(255);

                entity.Property(e => e.refer_lcno).HasMaxLength(255);

                entity.Property(e => e.refund_tax_amt).HasMaxLength(255);

                entity.Property(e => e.remark).HasMaxLength(255);

                entity.Property(e => e.shipmentFr).HasMaxLength(255);

                entity.Property(e => e.shipmentTo).HasMaxLength(255);

                entity.Property(e => e.spread_rate).HasMaxLength(255);

                entity.Property(e => e.tot_pc_day).HasMaxLength(255);

                entity.Property(e => e.total_amount).HasMaxLength(255);

                entity.Property(e => e.total_bal_ccy).HasMaxLength(255);

                entity.Property(e => e.total_bal_thb).HasMaxLength(255);

                entity.Property(e => e.total_charge).HasMaxLength(255);

                entity.Property(e => e.total_credit_ac).HasMaxLength(255);

                entity.Property(e => e.total_date).HasMaxLength(255);

                entity.Property(e => e.update_date).HasMaxLength(255);

                entity.Property(e => e.user_id).HasMaxLength(255);

                entity.Property(e => e.vouch_id).HasMaxLength(255);
            });

            modelBuilder.Entity<pExpcA>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pExpcA");

                entity.Property(e => e.ALLOCATION).HasMaxLength(255);

                entity.Property(e => e.AcBahtnet).HasMaxLength(255);

                entity.Property(e => e.AccruAmt).HasMaxLength(255);

                entity.Property(e => e.AccruCcy).HasMaxLength(255);

                entity.Property(e => e.AccruPending).HasMaxLength(255);

                entity.Property(e => e.Amend_no).HasMaxLength(255);

                entity.Property(e => e.ApproveBorad).HasMaxLength(255);

                entity.Property(e => e.AppvNo).HasMaxLength(255);

                entity.Property(e => e.AutoOverdue).HasMaxLength(255);

                entity.Property(e => e.BPOFlag).HasMaxLength(255);

                entity.Property(e => e.BahtNet).HasMaxLength(255);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(255);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(255);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(255);

                entity.Property(e => e.CCS_LmType).HasMaxLength(255);

                entity.Property(e => e.CFRRate).HasMaxLength(255);

                entity.Property(e => e.CalIntDate).HasMaxLength(255);

                entity.Property(e => e.Campaign_Code).HasMaxLength(255);

                entity.Property(e => e.Campaign_EffDate).HasMaxLength(255);

                entity.Property(e => e.CenterID).HasMaxLength(255);

                entity.Property(e => e.Com_Lieu).HasMaxLength(255);

                entity.Property(e => e.Comm_Certi).HasMaxLength(255);

                entity.Property(e => e.DAccruAmt).HasMaxLength(255);

                entity.Property(e => e.DMS).HasMaxLength(255);

                entity.Property(e => e.DateLastAccru).HasMaxLength(255);

                entity.Property(e => e.DateStartAccru).HasMaxLength(255);

                entity.Property(e => e.DateToStop).HasMaxLength(255);

                entity.Property(e => e.Due_no).HasMaxLength(255);

                entity.Property(e => e.FACNO).HasMaxLength(255);

                entity.Property(e => e.FcdAcc).HasMaxLength(255);

                entity.Property(e => e.FcdAmt).HasMaxLength(255);

                entity.Property(e => e.FixDate).HasMaxLength(255);

                entity.Property(e => e.FlagAmend).HasMaxLength(255);

                entity.Property(e => e.FlagBack).HasMaxLength(255);

                entity.Property(e => e.FlagSettle).HasMaxLength(255);

                entity.Property(e => e.FrontFee).HasMaxLength(255);

                entity.Property(e => e.IntBalance).HasMaxLength(255);

                entity.Property(e => e.IntBaseDay).HasMaxLength(255);

                entity.Property(e => e.IntFlag).HasMaxLength(255);

                entity.Property(e => e.IntRateCode).HasMaxLength(255);

                entity.Property(e => e.IntReceived).HasMaxLength(255);

                entity.Property(e => e.LastAccruAmt).HasMaxLength(255);

                entity.Property(e => e.LastAccruCcy).HasMaxLength(255);

                entity.Property(e => e.LastIntAmt).HasMaxLength(255);

                entity.Property(e => e.LastIntDate).HasMaxLength(255);

                entity.Property(e => e.LastPayDate).HasMaxLength(255);

                entity.Property(e => e.LastPrnthb).HasMaxLength(255);

                entity.Property(e => e.MidRate).HasMaxLength(255);

                entity.Property(e => e.NewAccruAmt).HasMaxLength(255);

                entity.Property(e => e.NewAccruCcy).HasMaxLength(255);

                entity.Property(e => e.OBASEDAY).HasMaxLength(255);

                entity.Property(e => e.OINTCODE).HasMaxLength(255);

                entity.Property(e => e.OINTCURRATE).HasMaxLength(255);

                entity.Property(e => e.OINTDAY).HasMaxLength(255);

                entity.Property(e => e.OINTRATE).HasMaxLength(255);

                entity.Property(e => e.OINTSPDRATE).HasMaxLength(255);

                entity.Property(e => e.ObjectType).HasMaxLength(255);

                entity.Property(e => e.OrderFlag).HasMaxLength(255);

                entity.Property(e => e.OveSeqno).HasMaxLength(255);

                entity.Property(e => e.PACKING_NO).HasMaxLength(255);

                entity.Property(e => e.PAccruAmt).HasMaxLength(255);

                entity.Property(e => e.PCOverdue).HasMaxLength(255);

                entity.Property(e => e.PCPastDue).HasMaxLength(255);

                entity.Property(e => e.PCProfit).HasMaxLength(255);

                entity.Property(e => e.PackNote).HasMaxLength(255);

                entity.Property(e => e.PastDueDate).HasMaxLength(255);

                entity.Property(e => e.PastDueFlag).HasMaxLength(255);

                entity.Property(e => e.PayNo).HasMaxLength(255);

                entity.Property(e => e.PaymentType).HasMaxLength(255);

                entity.Property(e => e.PcIntType).HasMaxLength(255);

                entity.Property(e => e.Pre_pack_ccy).HasMaxLength(255);

                entity.Property(e => e.Pre_pack_thb).HasMaxLength(255);

                entity.Property(e => e.PrnBalance).HasMaxLength(255);

                entity.Property(e => e.PurposeCode).HasMaxLength(255);

                entity.Property(e => e.REFUNDTAX).HasMaxLength(255);

                entity.Property(e => e.ReceivePayBy).HasMaxLength(255);

                entity.Property(e => e.Rel_code).HasMaxLength(255);

                entity.Property(e => e.RevAccru).HasMaxLength(255);

                entity.Property(e => e.RevAccruTax).HasMaxLength(255);

                entity.Property(e => e.SuspAmt).HasMaxLength(255);

                entity.Property(e => e.SuspBht).HasMaxLength(255);

                entity.Property(e => e.TaxRefund).HasMaxLength(255);

                entity.Property(e => e.TotalAccruAmt).HasMaxLength(255);

                entity.Property(e => e.TotalAccruBht).HasMaxLength(255);

                entity.Property(e => e.TotalSuspAmt).HasMaxLength(255);

                entity.Property(e => e.TotalSuspBht).HasMaxLength(255);

                entity.Property(e => e.UnderlyName).HasMaxLength(255);

                entity.Property(e => e.VALUE_DATE).HasMaxLength(255);

                entity.Property(e => e.ValueDate).HasMaxLength(255);

                entity.Property(e => e.applicant_name).HasMaxLength(255);

                entity.Property(e => e.auth_code).HasMaxLength(255);

                entity.Property(e => e.auth_date).HasMaxLength(255);

                entity.Property(e => e.business_type).HasMaxLength(255);

                entity.Property(e => e.cnty_code).HasMaxLength(255);

                entity.Property(e => e.comm_OnTT).HasMaxLength(255);

                entity.Property(e => e.comm_other).HasMaxLength(255);

                entity.Property(e => e.contra_bal).HasMaxLength(255);

                entity.Property(e => e.contra_date).HasMaxLength(255);

                entity.Property(e => e.current_60_daydue).HasMaxLength(255);

                entity.Property(e => e.current_intrate).HasMaxLength(255);

                entity.Property(e => e.current_pc_due).HasMaxLength(255);

                entity.Property(e => e.cust_id).HasMaxLength(255);

                entity.Property(e => e.cust_info).HasMaxLength(255);

                entity.Property(e => e.deduct_export_thb).HasMaxLength(255);

                entity.Property(e => e.doc_amount).HasMaxLength(255);

                entity.Property(e => e.doc_ccy).HasMaxLength(255);

                entity.Property(e => e.doc_expiry_date).HasMaxLength(255);

                entity.Property(e => e.duty_stamp).HasMaxLength(255);

                entity.Property(e => e.event_date).HasMaxLength(255);

                entity.Property(e => e.event_mode).HasMaxLength(255);

                entity.Property(e => e.event_no).HasMaxLength(255);

                entity.Property(e => e.event_type).HasMaxLength(255);

                entity.Property(e => e.exch_rate).HasMaxLength(255);

                entity.Property(e => e.exch_rate1).HasMaxLength(255);

                entity.Property(e => e.exch_rate2).HasMaxLength(255);

                entity.Property(e => e.exch_rate3).HasMaxLength(255);

                entity.Property(e => e.exch_rate4).HasMaxLength(255);

                entity.Property(e => e.exch_rate5).HasMaxLength(255);

                entity.Property(e => e.exch_rate6).HasMaxLength(255);

                entity.Property(e => e.exch_rate7).HasMaxLength(255);

                entity.Property(e => e.exch_rate8).HasMaxLength(255);

                entity.Property(e => e.exch_rate9).HasMaxLength(255);

                entity.Property(e => e.forward_contract1).HasMaxLength(255);

                entity.Property(e => e.forward_contract2).HasMaxLength(255);

                entity.Property(e => e.forward_contract3).HasMaxLength(255);

                entity.Property(e => e.forward_contract4).HasMaxLength(255);

                entity.Property(e => e.forward_contract5).HasMaxLength(255);

                entity.Property(e => e.forward_contract6).HasMaxLength(255);

                entity.Property(e => e.forward_contract7).HasMaxLength(255);

                entity.Property(e => e.forward_contract8).HasMaxLength(255);

                entity.Property(e => e.forward_contract9).HasMaxLength(255);

                entity.Property(e => e.genacc_date).HasMaxLength(255);

                entity.Property(e => e.genacc_flag).HasMaxLength(255);

                entity.Property(e => e.good_code).HasMaxLength(255);

                entity.Property(e => e.good_desc).HasMaxLength(255);

                entity.Property(e => e.handling_Fee).HasMaxLength(255);

                entity.Property(e => e.in_Use).HasMaxLength(255);

                entity.Property(e => e.interest_ccy1).HasMaxLength(255);

                entity.Property(e => e.interest_ccy2).HasMaxLength(255);

                entity.Property(e => e.interest_thb1).HasMaxLength(255);

                entity.Property(e => e.interest_thb2).HasMaxLength(255);

                entity.Property(e => e.method).HasMaxLength(255);

                entity.Property(e => e.new_pn_no).HasMaxLength(255);

                entity.Property(e => e.other_no).HasMaxLength(255);

                entity.Property(e => e.pack_ccy).HasMaxLength(255);

                entity.Property(e => e.pack_thb).HasMaxLength(255);

                entity.Property(e => e.pack_under).HasMaxLength(255);

                entity.Property(e => e.packing_for).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy1).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy2).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy3).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy4).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy5).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy6).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy7).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy8).HasMaxLength(255);

                entity.Property(e => e.partial_amt_ccy9).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb1).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb2).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb3).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb4).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb5).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb6).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb7).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb8).HasMaxLength(255);

                entity.Property(e => e.partial_amt_thb9).HasMaxLength(255);

                entity.Property(e => e.partial_full_rate).HasMaxLength(255);

                entity.Property(e => e.pay_instruc).HasMaxLength(255);

                entity.Property(e => e.pay_method).HasMaxLength(255);

                entity.Property(e => e.pay_rec_type).HasMaxLength(255);

                entity.Property(e => e.pc_int_rate).HasMaxLength(255);

                entity.Property(e => e.pc_start_date).HasMaxLength(255);

                entity.Property(e => e.penalty_amt).HasMaxLength(255);

                entity.Property(e => e.pn_no).HasMaxLength(255);

                entity.Property(e => e.prev_contra_bal).HasMaxLength(255);

                entity.Property(e => e.prev_start_date).HasMaxLength(255);

                entity.Property(e => e.principle_amt_ccy1).HasMaxLength(255);

                entity.Property(e => e.principle_amt_ccy2).HasMaxLength(255);

                entity.Property(e => e.principle_amt_ccy3).HasMaxLength(255);

                entity.Property(e => e.principle_amt_ccy4).HasMaxLength(255);

                entity.Property(e => e.principle_amt_thb1).HasMaxLength(255);

                entity.Property(e => e.principle_amt_thb2).HasMaxLength(255);

                entity.Property(e => e.principle_amt_thb3).HasMaxLength(255);

                entity.Property(e => e.principle_amt_thb4).HasMaxLength(255);

                entity.Property(e => e.principle_amt_thb5).HasMaxLength(255);

                entity.Property(e => e.rate).HasMaxLength(255);

                entity.Property(e => e.rec_status).HasMaxLength(255);

                entity.Property(e => e.received_no).HasMaxLength(255);

                entity.Property(e => e.record_type).HasMaxLength(255);

                entity.Property(e => e.refer_lcno).HasMaxLength(255);

                entity.Property(e => e.refund_tax_amt).HasMaxLength(255);

                entity.Property(e => e.remark).HasMaxLength(255);

                entity.Property(e => e.shipmentFr).HasMaxLength(255);

                entity.Property(e => e.shipmentTo).HasMaxLength(255);

                entity.Property(e => e.spread_rate).HasMaxLength(255);

                entity.Property(e => e.tot_pc_day).HasMaxLength(255);

                entity.Property(e => e.total_amount).HasMaxLength(255);

                entity.Property(e => e.total_bal_ccy).HasMaxLength(255);

                entity.Property(e => e.total_bal_thb).HasMaxLength(255);

                entity.Property(e => e.total_charge).HasMaxLength(255);

                entity.Property(e => e.total_credit_ac).HasMaxLength(255);

                entity.Property(e => e.total_date).HasMaxLength(255);

                entity.Property(e => e.update_date).HasMaxLength(255);

                entity.Property(e => e.user_id).HasMaxLength(255);

                entity.Property(e => e.vouch_id).HasMaxLength(255);
            });

            modelBuilder.Entity<pExpcOrder>(entity =>
            {
                entity.HasKey(e => new { e.DocNo, e.EventNo, e.Seqno })
                    .HasName("PK_pExpcOrderName");

                entity.ToTable("pExpcOrder");

                entity.Property(e => e.DocNo).HasMaxLength(15);

                entity.Property(e => e.OrderCnty).HasMaxLength(2);

                entity.Property(e => e.OrderName).HasMaxLength(70);
            });

            modelBuilder.Entity<pFCDText>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pFCDText");

                entity.HasIndex(e => new { e.Module, e.FcdAccNew, e.TranDocNew, e.Update_date }, "IX_pFCDText")
                    .IsUnique();

                entity.Property(e => e.AOCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AccCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AccType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ccy)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CustCode)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CustName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DateStartAccru)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DepositDate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DueDate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ERP_Acc_Code)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.EndMonthDate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.EventDate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FcdAccNew)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FcdAccOld)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FcdAccType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FcdSavFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.GenFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Module)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.OpenDate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.TermUnit)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TranDocNew)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TranDocOld)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TranFFlag)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Update_date)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ZZDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ZZuser)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<pFcdAccTran>(entity =>
            {
                entity.HasKey(e => new { e.FcdAccNo, e.FcdEntryDate, e.TranSeqNo, e.TranDoc })
                    .HasName("PK_pFcdAccount");

                entity.Property(e => e.FcdAccNo).HasMaxLength(13);

                entity.Property(e => e.FcdEntryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TranDoc).HasMaxLength(15);

                entity.Property(e => e.AccNo1).HasMaxLength(10);

                entity.Property(e => e.AccNo2).HasMaxLength(10);

                entity.Property(e => e.AccNo3).HasMaxLength(10);

                entity.Property(e => e.Allocation).HasMaxLength(10);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.ChqBank).HasMaxLength(20);

                entity.Property(e => e.ChqBran).HasMaxLength(70);

                entity.Property(e => e.ChqNo).HasMaxLength(20);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.DateLastPaid).HasColumnType("smalldatetime");

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FcdCcy).HasMaxLength(3);

                entity.Property(e => e.FcdCross)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FlagReverse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ForwardNo).HasMaxLength(15);

                entity.Property(e => e.FromDate).HasColumnType("smalldatetime");

                entity.Property(e => e.GoodsCode).HasMaxLength(3);

                entity.Property(e => e.LastReceiptNo).HasMaxLength(15);

                entity.Property(e => e.Mixpayment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Paytype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PurposeCode).HasMaxLength(6);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReceiptNo).HasMaxLength(15);

                entity.Property(e => e.RefAccount).HasMaxLength(35);

                entity.Property(e => e.RefTranDoc).HasMaxLength(20);

                entity.Property(e => e.RelateCode).HasMaxLength(6);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.TaxRefund)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ToDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TranCode).HasMaxLength(25);

                entity.Property(e => e.TranDept).HasMaxLength(3);

                entity.Property(e => e.TranFDepos).HasMaxLength(50);

                entity.Property(e => e.TranFMethod).HasMaxLength(15);

                entity.Property(e => e.TranFTel).HasMaxLength(10);

                entity.Property(e => e.TranFcdStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.VoucherID).HasMaxLength(15);
            });

            modelBuilder.Entity<pFcdDayBalance>(entity =>
            {
                entity.HasKey(e => new { e.FcdAccNo, e.TranDate, e.EffectDate });

                entity.ToTable("pFcdDayBalance");

                entity.Property(e => e.FcdAccNo).HasMaxLength(13);

                entity.Property(e => e.TranDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EffectDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.FcdAccType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FcdCcy).HasMaxLength(3);
            });

            modelBuilder.Entity<pFcdIntRate>(entity =>
            {
                entity.HasKey(e => new { e.Exch_Ccy, e.CreateTime, e.TranDate });

                entity.ToTable("pFcdIntRate");

                entity.Property(e => e.Exch_Ccy).HasMaxLength(3);

                entity.Property(e => e.CreateTime)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TranDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("datetime");

                entity.Property(e => e.Exch_CA).HasDefaultValueSql("((0))");

                entity.Property(e => e.Exch_SA).HasDefaultValueSql("((0))");

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<pHeaderForex>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pHeaderForex");

                entity.Property(e => e.FileCreateDate).HasColumnType("datetime");

                entity.Property(e => e.FileCreateTime).HasMaxLength(255);

                entity.Property(e => e.ProcessDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<pHoliday>(entity =>
            {
                entity.HasKey(e => new { e.Hol_Year, e.Hol_Date });

                entity.ToTable("pHoliday");

                entity.Property(e => e.Hol_Year)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Hol_Date).HasColumnType("datetime");

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("datetime");

                entity.Property(e => e.Hol_Desc).HasMaxLength(50);

                entity.Property(e => e.Hol_RecStat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<pIMBC>(entity =>
            {
                entity.HasKey(e => new { e.BCNumber, e.BCSeqno });

                entity.ToTable("pIMBC");

                entity.Property(e => e.BCNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AOCode).HasMaxLength(5);

                entity.Property(e => e.AcAddr).HasMaxLength(144);

                entity.Property(e => e.AcBank).HasMaxLength(14);

                entity.Property(e => e.AcceptDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AcceptFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Allocation).HasMaxLength(10);

                entity.Property(e => e.AmendFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AppvNo).HasMaxLength(15);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AutoOverDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BCCcy).HasMaxLength(3);

                entity.Property(e => e.BCOverDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BCStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BCType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BLNumber).HasMaxLength(35);

                entity.Property(e => e.BPOFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(20);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(20);

                entity.Property(e => e.CCS_LmType).HasMaxLength(3);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.ChipAcBank).HasMaxLength(20);

                entity.Property(e => e.ChipInterm).HasMaxLength(20);

                entity.Property(e => e.ChipReim).HasMaxLength(20);

                entity.Property(e => e.CustAddr).HasMaxLength(144);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.DMS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DateLastAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateLastPaid).HasColumnType("smalldatetime");

                entity.Property(e => e.Document).HasMaxLength(800);

                entity.Property(e => e.DraftDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DrawerCity).HasMaxLength(25);

                entity.Property(e => e.DrawerCnty).HasMaxLength(3);

                entity.Property(e => e.DrawerInfo).HasMaxLength(144);

                entity.Property(e => e.DrawerName).HasMaxLength(35);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Event).HasMaxLength(25);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventFlag).HasMaxLength(7);

                entity.Property(e => e.EventMode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FCyAcNo).HasMaxLength(15);

                entity.Property(e => e.FCyPayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FCyReceiptNo).HasMaxLength(15);

                entity.Property(e => e.FacNo).HasMaxLength(13);

                entity.Property(e => e.GenAccFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Goods).HasMaxLength(4);

                entity.Property(e => e.GoodsDesc).HasMaxLength(1000);

                entity.Property(e => e.INVNumber).HasMaxLength(50);

                entity.Property(e => e.InUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntRateCode).HasMaxLength(10);

                entity.Property(e => e.IntStartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.IntermAddr).HasMaxLength(144);

                entity.Property(e => e.IntermBank).HasMaxLength(14);

                entity.Property(e => e.LOCode).HasMaxLength(8);

                entity.Property(e => e.LastIntDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LastReceiptNo).HasMaxLength(15);

                entity.Property(e => e.MTNego)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MTNo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ObjectType).HasMaxLength(6);

                entity.Property(e => e.OverdueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayMethod).HasMaxLength(15);

                entity.Property(e => e.PayRemark).HasMaxLength(200);

                entity.Property(e => e.PayType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PrevDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PurposeCode).HasMaxLength(6);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReimAddr).HasMaxLength(144);

                entity.Property(e => e.ReimBank).HasMaxLength(14);

                entity.Property(e => e.RemitAddr).HasMaxLength(144);

                entity.Property(e => e.RemitBank).HasMaxLength(14);

                entity.Property(e => e.RemitChipUID).HasMaxLength(20);

                entity.Property(e => e.RemitCity).HasMaxLength(25);

                entity.Property(e => e.RemitCnty)
                    .HasMaxLength(2)
                    .IsFixedLength(true);

                entity.Property(e => e.RemitDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RemitFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RemitRefno).HasMaxLength(25);

                entity.Property(e => e.SGNumber).HasMaxLength(15);

                entity.Property(e => e.SGNumber1).HasMaxLength(15);

                entity.Property(e => e.SGNumber2).HasMaxLength(15);

                entity.Property(e => e.SGNumber3).HasMaxLength(15);

                entity.Property(e => e.SGNumber4).HasMaxLength(15);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TaxRefund)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenorTerm).HasMaxLength(50);

                entity.Property(e => e.ThirdAddr).HasMaxLength(144);

                entity.Property(e => e.ThirdBank).HasMaxLength(14);

                entity.Property(e => e.ThirdRefno).HasMaxLength(25);

                entity.Property(e => e.TransBy)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TransFrom)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Tx23E).HasMaxLength(4);

                entity.Property(e => e.Tx26)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Tx59A).HasMaxLength(35);

                entity.Property(e => e.Tx59D).HasMaxLength(144);

                entity.Property(e => e.Tx70).HasMaxLength(144);

                entity.Property(e => e.Tx71A).HasMaxLength(10);

                entity.Property(e => e.Tx72).HasMaxLength(432);

                entity.Property(e => e.Tx79).HasMaxLength(2100);

                entity.Property(e => e.UnderlyName).HasMaxLength(250);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.VoucherID).HasMaxLength(15);
            });

            modelBuilder.Entity<pIMBL>(entity =>
            {
                entity.HasKey(e => new { e.ADNumber, e.RecType, e.BLSeqno });

                entity.ToTable("pIMBL");

                entity.Property(e => e.ADNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AOCode).HasMaxLength(5);

                entity.Property(e => e.AcBank).HasMaxLength(14);

                entity.Property(e => e.AdviceDisc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AdviceResult)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Allocation).HasMaxLength(10);

                entity.Property(e => e.AppvNo).HasMaxLength(15);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AutoOverDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BLCcy).HasMaxLength(3);

                entity.Property(e => e.BLNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BLOverDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BLStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BPOFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BenCnty).HasMaxLength(2);

                entity.Property(e => e.BenInfo).HasMaxLength(144);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(20);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(20);

                entity.Property(e => e.CCS_LmType).HasMaxLength(3);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.ChipAcBank).HasMaxLength(20);

                entity.Property(e => e.ChipInterm).HasMaxLength(20);

                entity.Property(e => e.ChipNego).HasMaxLength(20);

                entity.Property(e => e.CommBenCcy).HasDefaultValueSql("((0))");

                entity.Property(e => e.CommDesc).HasMaxLength(200);

                entity.Property(e => e.CustAddr).HasMaxLength(144);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.DMS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DateLastAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateLastPaid).HasColumnType("smalldatetime");

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateToStop).HasColumnType("smalldatetime");

                entity.Property(e => e.DeductCcy).HasMaxLength(3);

                entity.Property(e => e.Discrepancy).HasMaxLength(1500);

                entity.Property(e => e.DocCCy).HasMaxLength(3);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Event).HasMaxLength(25);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventFlag).HasMaxLength(7);

                entity.Property(e => e.EventMode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FBCcy).HasMaxLength(3);

                entity.Property(e => e.FCyAcNo).HasMaxLength(15);

                entity.Property(e => e.FCyPayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FCyReceiptNo).HasMaxLength(15);

                entity.Property(e => e.FacNo).HasMaxLength(13);

                entity.Property(e => e.GenAccFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.GoodsFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.InUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Instruction).HasMaxLength(1000);

                entity.Property(e => e.IntFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntRateCode).HasMaxLength(10);

                entity.Property(e => e.IntStartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.IntermBank).HasMaxLength(14);

                entity.Property(e => e.IssueAdvice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LC740)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LCBal).HasDefaultValueSql("((0))");

                entity.Property(e => e.LCNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LOCode).HasMaxLength(8);

                entity.Property(e => e.LastIntDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LastReceiptNo).HasMaxLength(15);

                entity.Property(e => e.MT799)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT999)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MTNo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MTTelex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NegoACNo).HasMaxLength(20);

                entity.Property(e => e.NegoAddr).HasMaxLength(144);

                entity.Property(e => e.NegoBank).HasMaxLength(14);

                entity.Property(e => e.NegoCity).HasMaxLength(20);

                entity.Property(e => e.NegoCnty).HasMaxLength(2);

                entity.Property(e => e.NegoDate).HasColumnType("smalldatetime");

                entity.Property(e => e.NegoRefno).HasMaxLength(25);

                entity.Property(e => e.ObjectType).HasMaxLength(6);

                entity.Property(e => e.OverdueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PastDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PastDueFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayMethod).HasMaxLength(15);

                entity.Property(e => e.PayRemark).HasMaxLength(50);

                entity.Property(e => e.PayType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PrevDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PurposeCode).HasMaxLength(6);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReimBank).HasMaxLength(14);

                entity.Property(e => e.RemitDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RemitFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SGNumber).HasMaxLength(15);

                entity.Property(e => e.SGNumber1).HasMaxLength(15);

                entity.Property(e => e.SGNumber2).HasMaxLength(15);

                entity.Property(e => e.SettleFlag).HasMaxLength(20);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TaxRefund)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenorTerm).HasMaxLength(30);

                entity.Property(e => e.TenorType).HasMaxLength(20);

                entity.Property(e => e.UnderlyName).HasMaxLength(250);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.ValueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.VoucherID).HasMaxLength(15);
            });

            modelBuilder.Entity<pIMBLDoc>(entity =>
            {
                entity.HasKey(e => new { e.ADNumber, e.SeqNo });

                entity.Property(e => e.ADNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.Copy).HasMaxLength(10);

                entity.Property(e => e.DocDetails).HasMaxLength(150);

                entity.Property(e => e.OrgCopy).HasMaxLength(10);
            });

            modelBuilder.Entity<pIMBLText>(entity =>
            {
                entity.HasKey(e => new { e.ADNumber, e.Seqno });

                entity.ToTable("pIMBLText");

                entity.Property(e => e.ADNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.Text23).HasMaxLength(16);

                entity.Property(e => e.Text72).HasMaxLength(432);

                entity.Property(e => e.Text77).HasMaxLength(432);

                entity.Property(e => e.Text79).HasMaxLength(2100);

                entity.Property(e => e.Text79_1).HasMaxLength(2100);

                entity.Property(e => e.Text79_2).HasMaxLength(2100);
            });

            modelBuilder.Entity<pIMBackPay>(entity =>
            {
                entity.HasKey(e => new { e.Login, e.RefNumber, e.EventNo });

                entity.ToTable("pIMBackPay");

                entity.Property(e => e.Login)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RefNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DocNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Event).HasMaxLength(25);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LastIntDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Reverse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VoucherID).HasMaxLength(13);
            });

            modelBuilder.Entity<pIMInstall>(entity =>
            {
                entity.HasKey(e => new { e.DocNo, e.EventNo, e.Seqno });

                entity.ToTable("pIMInstall");

                entity.Property(e => e.DocNo).HasMaxLength(15);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pIMInterest>(entity =>
            {
                entity.HasKey(e => new { e.Login, e.Event, e.DocNo, e.EventNo, e.Seqno });

                entity.ToTable("pIMInterest");

                entity.Property(e => e.Login).HasMaxLength(4);

                entity.Property(e => e.Event).HasMaxLength(15);

                entity.Property(e => e.DocNo).HasMaxLength(15);

                entity.Property(e => e.CalDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.IntCode).HasMaxLength(10);

                entity.Property(e => e.IntFrom).HasColumnType("smalldatetime");

                entity.Property(e => e.IntTo).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pIMLC>(entity =>
            {
                entity.HasKey(e => new { e.LCNumber, e.LCSeqno, e.RecType });

                entity.ToTable("pIMLC");

                entity.Property(e => e.LCNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AOCode).HasMaxLength(5);

                entity.Property(e => e.AdBankCode).HasMaxLength(14);

                entity.Property(e => e.AdThruBank).HasMaxLength(14);

                entity.Property(e => e.AdThruCity).HasMaxLength(25);

                entity.Property(e => e.AdThruCnty).HasMaxLength(2);

                entity.Property(e => e.AdThruInfo1).HasMaxLength(148);

                entity.Property(e => e.Allocation).HasMaxLength(10);

                entity.Property(e => e.AllowMinus).HasDefaultValueSql("((0))");

                entity.Property(e => e.AllowPlus).HasDefaultValueSql("((0))");

                entity.Property(e => e.AmendAmt).HasDefaultValueSql("((0))");

                entity.Property(e => e.AmendFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))")
                    .IsFixedLength(true);

                entity.Property(e => e.AmendMinus).HasDefaultValueSql("((0))");

                entity.Property(e => e.AmendNo).HasMaxLength(15);

                entity.Property(e => e.AmendPlus).HasDefaultValueSql("((0))");

                entity.Property(e => e.AmendSeq).HasDefaultValueSql("((0))");

                entity.Property(e => e.AmendStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AppvNo).HasMaxLength(15);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AvailBy).HasMaxLength(16);

                entity.Property(e => e.AvailCnty).HasMaxLength(148);

                entity.Property(e => e.AvailWith).HasMaxLength(16);

                entity.Property(e => e.BPOFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Bank740).HasMaxLength(224);

                entity.Property(e => e.BanktoBank72).HasMaxLength(224);

                entity.Property(e => e.BenCity).HasMaxLength(25);

                entity.Property(e => e.BenCnty).HasMaxLength(2);

                entity.Property(e => e.BenInfo1).HasMaxLength(35);

                entity.Property(e => e.BenInfo2).HasMaxLength(35);

                entity.Property(e => e.BenInfo3).HasMaxLength(35);

                entity.Property(e => e.BenInfo4).HasMaxLength(35);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(20);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(20);

                entity.Property(e => e.CCS_LmType).HasMaxLength(3);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.Charge71B).HasMaxLength(224);

                entity.Property(e => e.Charge740).HasMaxLength(224);

                entity.Property(e => e.CollectRefund)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CommLCRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.CommType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ConfBankCode).HasMaxLength(14);

                entity.Property(e => e.ConfirmComm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ConfirmRequest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Confirmation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CustAddr).HasMaxLength(144);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.DateExpiry).HasColumnType("smalldatetime");

                entity.Property(e => e.DateExpiryMax).HasColumnType("smalldatetime");

                entity.Property(e => e.DateIssue).HasColumnType("smalldatetime");

                entity.Property(e => e.DateLastPaid).HasColumnType("smalldatetime");

                entity.Property(e => e.DateLateShip).HasColumnType("smalldatetime");

                entity.Property(e => e.DateMT740).HasColumnType("smalldatetime");

                entity.Property(e => e.DePlus_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DraftAt).HasMaxLength(108);

                entity.Property(e => e.Drawee).HasMaxLength(40);

                entity.Property(e => e.Event).HasMaxLength(25);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventFlag).HasMaxLength(7);

                entity.Property(e => e.ExchRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.FacNo).HasMaxLength(13);

                entity.Property(e => e.GenAccFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.GoodsCode).HasMaxLength(3);

                entity.Property(e => e.InUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Incoterms).HasMaxLength(20);

                entity.Property(e => e.LCAmt).HasDefaultValueSql("((0))");

                entity.Property(e => e.LCAvalBal).HasDefaultValueSql("((0))");

                entity.Property(e => e.LCBal).HasDefaultValueSql("((0))");

                entity.Property(e => e.LCCcy).HasMaxLength(3);

                entity.Property(e => e.LCDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.LCForm).HasMaxLength(50);

                entity.Property(e => e.LCReferNo).HasMaxLength(16);

                entity.Property(e => e.LCRevolve)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LCSentBy).HasMaxLength(15);

                entity.Property(e => e.LCStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LCVary)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LOCode).HasMaxLength(8);

                entity.Property(e => e.LastReceiptNo).HasMaxLength(15);

                entity.Property(e => e.MT747_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MixPayment).HasMaxLength(650);

                entity.Property(e => e.ObjectType).HasMaxLength(6);

                entity.Property(e => e.OutsideCharge)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PartialShipment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayMethod).HasMaxLength(15);

                entity.Property(e => e.PayRemark).HasMaxLength(200);

                entity.Property(e => e.PeriodComm).HasDefaultValueSql("((0))");

                entity.Property(e => e.PeriodCommExt).HasDefaultValueSql("((0))");

                entity.Property(e => e.PlaceExpiry).HasMaxLength(29);

                entity.Property(e => e.PostageAmt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PresentDay).HasDefaultValueSql("((0))");

                entity.Property(e => e.PresentPeriod).HasMaxLength(144);

                entity.Property(e => e.PrevAmt).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrevBenInfo).HasMaxLength(144);

                entity.Property(e => e.PrevDateExpMax).HasColumnType("smalldatetime");

                entity.Property(e => e.PrevDateExpiry).HasColumnType("smalldatetime");

                entity.Property(e => e.PrevLCAvalBal).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrevLCBal).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrevLCDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrevMunus).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrevPlus).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurposeCode).HasMaxLength(6);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReimAddr).HasMaxLength(144);

                entity.Property(e => e.ReimBank).HasMaxLength(14);

                entity.Property(e => e.ReimCharge)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReimMT740).HasMaxLength(3);

                entity.Property(e => e.ReimNote).HasMaxLength(792);

                entity.Property(e => e.ReimPay).HasMaxLength(15);

                entity.Property(e => e.RequestCancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Restricted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ShipPlace).HasMaxLength(65);

                entity.Property(e => e.ShipmentFrom).HasMaxLength(65);

                entity.Property(e => e.TaxRefund)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenorTerm).HasMaxLength(30);

                entity.Property(e => e.TenorType).HasMaxLength(20);

                entity.Property(e => e.Transhipment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TransportTo).HasMaxLength(65);

                entity.Property(e => e.TransportType).HasMaxLength(50);

                entity.Property(e => e.UnderlyName).HasMaxLength(250);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.VoucherID).HasMaxLength(15);
            });

            modelBuilder.Entity<pIMLCAmend>(entity =>
            {
                entity.HasKey(e => new { e.LCNumber, e.RecType, e.LCSeqno });

                entity.ToTable("pIMLCAmend");

                entity.Property(e => e.LCNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Amend79)
                    .HasMaxLength(1820)
                    .IsUnicode(false);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.Narr77A)
                    .HasMaxLength(740)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<pIMLCCond>(entity =>
            {
                entity.HasKey(e => new { e.LCNumber, e.RecType, e.LCSeqno, e.MT })
                    .HasName("PK_pIMLCCond47");

                entity.ToTable("pIMLCCond");

                entity.Property(e => e.LCNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AddCondition)
                    .HasMaxLength(6600)
                    .IsUnicode(false);

                entity.Property(e => e.CenterID).HasMaxLength(4);
            });

            modelBuilder.Entity<pIMLCDoc>(entity =>
            {
                entity.HasKey(e => new { e.LCNumber, e.RecType, e.LCSeqno, e.MT })
                    .HasName("PK_pIMLCDoc46");

                entity.Property(e => e.LCNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.DocRequire)
                    .HasMaxLength(6600)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<pIMLCGood>(entity =>
            {
                entity.HasKey(e => new { e.LCNumber, e.RecType, e.LCSeqno, e.MT });

                entity.Property(e => e.LCNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.GoodsDesc)
                    .HasMaxLength(6600)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<pIMLCText>(entity =>
            {
                entity.HasKey(e => new { e.LCNumber, e.RecType, e.LCSeqno });

                entity.ToTable("pIMLCText");

                entity.Property(e => e.LCNumber)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AddCondition).HasMaxLength(3300);

                entity.Property(e => e.Amend79).HasMaxLength(1800);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.DocRequire).HasMaxLength(3300);

                entity.Property(e => e.MT202_56A).HasMaxLength(11);

                entity.Property(e => e.MT202_56D).HasMaxLength(144);

                entity.Property(e => e.MT202_57A).HasMaxLength(11);

                entity.Property(e => e.MT202_57D).HasMaxLength(144);

                entity.Property(e => e.MT202_58A).HasMaxLength(11);

                entity.Property(e => e.MT202_58D).HasMaxLength(144);

                entity.Property(e => e.Narr77A).HasMaxLength(720);

                entity.Property(e => e.PresentPeriod).HasMaxLength(144);
            });

            modelBuilder.Entity<pIMMiscTran>(entity =>
            {
                entity.HasKey(e => new { e.Login, e.RefNumber, e.Seqno, e.DocNumber });

                entity.ToTable("pIMMiscTran");

                entity.Property(e => e.Login).HasMaxLength(4);

                entity.Property(e => e.RefNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DocNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AcAddr).HasMaxLength(144);

                entity.Property(e => e.AcBank).HasMaxLength(14);

                entity.Property(e => e.Allocation).HasMaxLength(10);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Bank52).HasMaxLength(15);

                entity.Property(e => e.Bank54).HasMaxLength(15);

                entity.Property(e => e.BenAddr).HasMaxLength(144);

                entity.Property(e => e.BenBank).HasMaxLength(14);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.ChipAcBank).HasMaxLength(35);

                entity.Property(e => e.ChipBank53).HasMaxLength(35);

                entity.Property(e => e.ChipBank54).HasMaxLength(35);

                entity.Property(e => e.ChipBenBank).HasMaxLength(35);

                entity.Property(e => e.ChipInterm).HasMaxLength(35);

                entity.Property(e => e.CustAddr).HasMaxLength(144);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.Cust_Bran).HasMaxLength(3);

                entity.Property(e => e.DMS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DateGenAc).HasColumnType("smalldatetime");

                entity.Property(e => e.DateLastPaid).HasColumnType("smalldatetime");

                entity.Property(e => e.DocCcy).HasMaxLength(3);

                entity.Property(e => e.DocDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Event).HasMaxLength(25);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventFlag)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FBCcy).HasMaxLength(3);

                entity.Property(e => e.FCDAcNo).HasMaxLength(15);

                entity.Property(e => e.FCDReceiptNo).HasMaxLength(15);

                entity.Property(e => e.GenAccFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.InUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntermAddr).HasMaxLength(144);

                entity.Property(e => e.IntermBank).HasMaxLength(14);

                entity.Property(e => e.LastReceiptNo).HasMaxLength(15);

                entity.Property(e => e.MTType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayMethod).HasMaxLength(15);

                entity.Property(e => e.ProdCode).HasMaxLength(15);

                entity.Property(e => e.ProdDesc).HasMaxLength(50);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReimBank).HasMaxLength(14);

                entity.Property(e => e.ReimRefNo).HasMaxLength(16);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.SwiftFile).HasMaxLength(35);

                entity.Property(e => e.TaxRefund)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Tx72).HasMaxLength(432);

                entity.Property(e => e.Tx79).HasMaxLength(2100);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.VoucherID).HasMaxLength(15);
            });

            modelBuilder.Entity<pIMMiscTranx>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pIMMiscTranx");

                entity.Property(e => e.AcAddr).HasMaxLength(255);

                entity.Property(e => e.AcBank).HasMaxLength(255);

                entity.Property(e => e.Allocation).HasMaxLength(255);

                entity.Property(e => e.AuthCode).HasMaxLength(255);

                entity.Property(e => e.AuthDate).HasMaxLength(255);

                entity.Property(e => e.Bank52).HasMaxLength(255);

                entity.Property(e => e.Bank54).HasMaxLength(255);

                entity.Property(e => e.BenAddr).HasMaxLength(255);

                entity.Property(e => e.BenBank).HasMaxLength(255);

                entity.Property(e => e.CableMail).HasMaxLength(255);

                entity.Property(e => e.CenterID).HasMaxLength(255);

                entity.Property(e => e.ChipAcBank).HasMaxLength(255);

                entity.Property(e => e.ChipBank52).HasMaxLength(255);

                entity.Property(e => e.ChipBank53).HasMaxLength(255);

                entity.Property(e => e.ChipBank54).HasMaxLength(255);

                entity.Property(e => e.ChipBenBank).HasMaxLength(255);

                entity.Property(e => e.ChipInterm).HasMaxLength(255);

                entity.Property(e => e.CommCCy).HasMaxLength(255);

                entity.Property(e => e.CommOther).HasMaxLength(255);

                entity.Property(e => e.CustAddr).HasMaxLength(255);

                entity.Property(e => e.CustCode).HasMaxLength(255);

                entity.Property(e => e.Cust_Bran).HasMaxLength(255);

                entity.Property(e => e.DMS).HasMaxLength(255);

                entity.Property(e => e.DateGenAc).HasMaxLength(255);

                entity.Property(e => e.DateLastPaid).HasMaxLength(255);

                entity.Property(e => e.DocBalance).HasMaxLength(255);

                entity.Property(e => e.DocCcy).HasMaxLength(255);

                entity.Property(e => e.DocCommCcy).HasMaxLength(255);

                entity.Property(e => e.DocDate).HasMaxLength(255);

                entity.Property(e => e.DocFBCharge).HasMaxLength(255);

                entity.Property(e => e.DocFBInterest).HasMaxLength(255);

                entity.Property(e => e.DocNumber).HasMaxLength(255);

                entity.Property(e => e.DocStatus).HasMaxLength(255);

                entity.Property(e => e.Event).HasMaxLength(255);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventFlag).HasMaxLength(255);

                entity.Property(e => e.ExchRate).HasMaxLength(255);

                entity.Property(e => e.FBCcy).HasMaxLength(255);

                entity.Property(e => e.FBCharge).HasMaxLength(255);

                entity.Property(e => e.FBInterest).HasMaxLength(255);

                entity.Property(e => e.FCDAcNo).HasMaxLength(255);

                entity.Property(e => e.FCDReceiptNo).HasMaxLength(255);

                entity.Property(e => e.GenAccFlag).HasMaxLength(255);

                entity.Property(e => e.InUse).HasMaxLength(255);

                entity.Property(e => e.IntermAddr).HasMaxLength(255);

                entity.Property(e => e.IntermBank).HasMaxLength(255);

                entity.Property(e => e.LastReceiptNo).HasMaxLength(255);

                entity.Property(e => e.Login).HasMaxLength(255);

                entity.Property(e => e.MTType).HasMaxLength(255);

                entity.Property(e => e.MarginAmt).HasMaxLength(255);

                entity.Property(e => e.PayFlag).HasMaxLength(255);

                entity.Property(e => e.PayMethod).HasMaxLength(255);

                entity.Property(e => e.ProdCode).HasMaxLength(255);

                entity.Property(e => e.ProdDesc).HasMaxLength(255);

                entity.Property(e => e.RecStatus).HasMaxLength(255);

                entity.Property(e => e.RefNumber).HasMaxLength(255);

                entity.Property(e => e.ReimBank).HasMaxLength(255);

                entity.Property(e => e.ReimRefNo).HasMaxLength(255);

                entity.Property(e => e.Remark).HasMaxLength(255);

                entity.Property(e => e.SwiftFile).HasMaxLength(255);

                entity.Property(e => e.TaxAmt).HasMaxLength(255);

                entity.Property(e => e.TaxRefund).HasMaxLength(255);

                entity.Property(e => e.Tx72).HasMaxLength(255);

                entity.Property(e => e.Tx79).HasMaxLength(255);

                entity.Property(e => e.UpdateDate).HasMaxLength(255);

                entity.Property(e => e.UserCode).HasMaxLength(255);

                entity.Property(e => e.VoucherID).HasMaxLength(255);
            });

            modelBuilder.Entity<pIMPastDue>(entity =>
            {
                entity.HasKey(e => new { e.CenterID, e.DocModule, e.DocNumber, e.RecType, e.DocSeqno });

                entity.ToTable("pIMPastDue");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.DocModule).HasMaxLength(15);

                entity.Property(e => e.DocNumber).HasMaxLength(15);

                entity.Property(e => e.RecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AOCode).HasMaxLength(5);

                entity.Property(e => e.Allocation).HasMaxLength(10);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.BPOFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(20);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(20);

                entity.Property(e => e.CCS_LmType).HasMaxLength(3);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CommDesc).HasMaxLength(200);

                entity.Property(e => e.CustAddr).HasMaxLength(144);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.DMS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DateLastAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateLastPaid).HasColumnType("smalldatetime");

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateToStop).HasColumnType("smalldatetime");

                entity.Property(e => e.DocCcy).HasMaxLength(3);

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Event).HasMaxLength(25);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventFlag).HasMaxLength(7);

                entity.Property(e => e.EventMode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FacNo).HasMaxLength(13);

                entity.Property(e => e.GenAccFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.InUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntRateCode).HasMaxLength(10);

                entity.Property(e => e.IntStartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LCNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LOCode).HasMaxLength(8);

                entity.Property(e => e.LastIntDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LastReceiptNo).HasMaxLength(15);

                entity.Property(e => e.OverdueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PastDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayMethod).HasMaxLength(15);

                entity.Property(e => e.PayRemark).HasMaxLength(200);

                entity.Property(e => e.PayType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PaymentDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TaxRefund)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenorType).HasMaxLength(5);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.VoucherID).HasMaxLength(15);
            });

            modelBuilder.Entity<pIMPayment>(entity =>
            {
                entity.HasKey(e => new { e.DocNumber, e.DocSeqno })
                    .HasName("PK_pDocPayment");

                entity.ToTable("pIMPayment");

                entity.Property(e => e.DocNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BalanceAmt).HasDefaultValueSql("((0))");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.DateLastAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateToStop).HasColumnType("smalldatetime");

                entity.Property(e => e.FwdCont).HasMaxLength(15);

                entity.Property(e => e.FwdCont2).HasMaxLength(15);

                entity.Property(e => e.FwdCont3).HasMaxLength(15);

                entity.Property(e => e.FwdCont4).HasMaxLength(15);

                entity.Property(e => e.FwdCont5).HasMaxLength(15);

                entity.Property(e => e.FwdCont6).HasMaxLength(15);

                entity.Property(e => e.FwdContInt1).HasMaxLength(15);

                entity.Property(e => e.FwdContInt2).HasMaxLength(15);

                entity.Property(e => e.InterestAmt).HasDefaultValueSql("((0))");

                entity.Property(e => e.OverDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PastdueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PayAmtBht1).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayAmtBht2).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayAmtBht3).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayAmtBht4).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayAmtBht5).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayAmtBht6).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayBaht1).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayBaht2).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayBaht3).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayBaht4).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayBaht5).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayBaht6).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayCcyAmt).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayCcyInt).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayExch1).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayExch2).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayExch3).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayExch4).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayExch5).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayExch6).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayFCD).HasMaxLength(20);

                entity.Property(e => e.PayFlag)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayIntBaht1).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayIntBaht2).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayIntBht1).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayIntBht2).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayIntExch1).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayIntExch2).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayMode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PaymentDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TRDueStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<pIMSG>(entity =>
            {
                entity.HasKey(e => new { e.SGNumber, e.RecType, e.SGSeqno });

                entity.ToTable("pIMSG");

                entity.Property(e => e.SGNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AOCode).HasMaxLength(5);

                entity.Property(e => e.Allocation).HasMaxLength(10);

                entity.Property(e => e.AppvNo).HasMaxLength(15);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.BLNumber).HasMaxLength(35);

                entity.Property(e => e.BPOFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BenInfo).HasMaxLength(110);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(20);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(20);

                entity.Property(e => e.CCS_LmType).HasMaxLength(3);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.DateLastPaid).HasColumnType("smalldatetime");

                entity.Property(e => e.Event).HasMaxLength(25);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventMode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FacNo).HasMaxLength(13);

                entity.Property(e => e.GENACC_FLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.HouseAwb).HasMaxLength(35);

                entity.Property(e => e.InUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.InvNumber).HasMaxLength(65);

                entity.Property(e => e.LOCode).HasMaxLength(8);

                entity.Property(e => e.LastReceiptNo).HasMaxLength(15);

                entity.Property(e => e.MasterAwb).HasMaxLength(35);

                entity.Property(e => e.PayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayMethod).HasMaxLength(15);

                entity.Property(e => e.PayRelation).HasMaxLength(6);

                entity.Property(e => e.PayRemark).HasMaxLength(200);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReferLC).HasMaxLength(15);

                entity.Property(e => e.RefundFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.SGCcy).HasMaxLength(3);

                entity.Property(e => e.SGMode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SGStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SGType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Shipping).HasMaxLength(100);

                entity.Property(e => e.SupStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.VOUCHER_ID).HasMaxLength(15);

                entity.Property(e => e.Vessel).HasMaxLength(100);
            });

            modelBuilder.Entity<pIMTR>(entity =>
            {
                entity.HasKey(e => new { e.RefNumber, e.RecType, e.TRSeqno });

                entity.ToTable("pIMTR");

                entity.Property(e => e.RefNumber).HasMaxLength(15);

                entity.Property(e => e.RecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AOCode).HasMaxLength(5);

                entity.Property(e => e.AcAddr).HasMaxLength(144);

                entity.Property(e => e.AcBank).HasMaxLength(14);

                entity.Property(e => e.Allocation).HasMaxLength(10);

                entity.Property(e => e.AppvNo).HasMaxLength(15);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AutoOverDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BLAdvice).HasMaxLength(15);

                entity.Property(e => e.BLBalance).HasDefaultValueSql("((0))");

                entity.Property(e => e.BLFwd).HasMaxLength(15);

                entity.Property(e => e.BLIntCode).HasMaxLength(10);

                entity.Property(e => e.BLIntStartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.BLNumber).HasMaxLength(15);

                entity.Property(e => e.BPOFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BenCnty).HasMaxLength(2);

                entity.Property(e => e.BenInfo).HasMaxLength(144);

                entity.Property(e => e.BenName).HasMaxLength(35);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(20);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(20);

                entity.Property(e => e.CCS_LmType).HasMaxLength(3);

                entity.Property(e => e.CFRRate).HasMaxLength(20);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.ChipAcBank).HasMaxLength(20);

                entity.Property(e => e.ChipInterm).HasMaxLength(20);

                entity.Property(e => e.ChipNego).HasMaxLength(20);

                entity.Property(e => e.CommDesc).HasMaxLength(200);

                entity.Property(e => e.CustAddr).HasMaxLength(144);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.DMS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DateLastAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateLastPaid).HasColumnType("smalldatetime");

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateToStop).HasColumnType("smalldatetime");

                entity.Property(e => e.DocCCy).HasMaxLength(3);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Event).HasMaxLength(25);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.EventMode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FBCcy).HasMaxLength(3);

                entity.Property(e => e.FCyAcNo).HasMaxLength(15);

                entity.Property(e => e.FCyPayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FCyReceiptNo).HasMaxLength(15);

                entity.Property(e => e.FacNo).HasMaxLength(13);

                entity.Property(e => e.GenAccFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Goods).HasMaxLength(3);

                entity.Property(e => e.InUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntFixDate).HasMaxLength(2);

                entity.Property(e => e.IntFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntPayType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntRateCode).HasMaxLength(10);

                entity.Property(e => e.IntStartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.IntermAddr).HasMaxLength(144);

                entity.Property(e => e.IntermBank).HasMaxLength(14);

                entity.Property(e => e.Invoice).HasMaxLength(50);

                entity.Property(e => e.LCNumber).HasMaxLength(15);

                entity.Property(e => e.LOCode).HasMaxLength(8);

                entity.Property(e => e.LastIntDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LastReceiptNo).HasMaxLength(15);

                entity.Property(e => e.MTNego)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MTType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Nego799)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Nego999)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NegoBank).HasMaxLength(14);

                entity.Property(e => e.NegoCnty).HasMaxLength(2);

                entity.Property(e => e.NegoRefno).HasMaxLength(25);

                entity.Property(e => e.NegoTelex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NostACInfo).HasMaxLength(20);

                entity.Property(e => e.ObjectType).HasMaxLength(6);

                entity.Property(e => e.OverdueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PastDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayMethod).HasMaxLength(15);

                entity.Property(e => e.PayType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PrevDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PurposeCode).HasMaxLength(6);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReimBank).HasMaxLength(14);

                entity.Property(e => e.Relation).HasMaxLength(6);

                entity.Property(e => e.SGNumber).HasMaxLength(15);

                entity.Property(e => e.SGNumber1).HasMaxLength(15);

                entity.Property(e => e.SettleDate).HasColumnType("smalldatetime");

                entity.Property(e => e.SettleFlag).HasMaxLength(20);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TRCCyFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TRCcy).HasMaxLength(3);

                entity.Property(e => e.TRCont1).HasMaxLength(15);

                entity.Property(e => e.TRCont2).HasMaxLength(15);

                entity.Property(e => e.TRCont3).HasMaxLength(15);

                entity.Property(e => e.TRCont4).HasMaxLength(15);

                entity.Property(e => e.TRCont5).HasMaxLength(15);

                entity.Property(e => e.TRDueStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TRFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TRNumber).HasMaxLength(35);

                entity.Property(e => e.TRRate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TRStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TaxRefund)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenorType).HasMaxLength(20);

                entity.Property(e => e.Tx23E).HasMaxLength(4);

                entity.Property(e => e.Tx26)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Tx59A).HasMaxLength(35);

                entity.Property(e => e.Tx59Cnty).HasMaxLength(2);

                entity.Property(e => e.Tx59D).HasMaxLength(144);

                entity.Property(e => e.Tx71A).HasMaxLength(10);

                entity.Property(e => e.Tx72).HasMaxLength(432);

                entity.Property(e => e.UnderlyName).HasMaxLength(250);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.ValueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.VoucherID).HasMaxLength(15);
            });

            modelBuilder.Entity<pIMTR2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pIMTR2");

                entity.Property(e => e.AOCode).HasMaxLength(255);

                entity.Property(e => e.AcAddr).HasMaxLength(255);

                entity.Property(e => e.AcBank).HasMaxLength(255);

                entity.Property(e => e.AccruAmt).HasMaxLength(255);

                entity.Property(e => e.AccruCCy).HasMaxLength(255);

                entity.Property(e => e.AccruPending).HasMaxLength(255);

                entity.Property(e => e.Allocation).HasMaxLength(255);

                entity.Property(e => e.AppvNo).HasMaxLength(255);

                entity.Property(e => e.AuthCode).HasMaxLength(255);

                entity.Property(e => e.AuthDate).HasColumnType("datetime");

                entity.Property(e => e.AutoOverDue).HasMaxLength(255);

                entity.Property(e => e.BLAdvice).HasMaxLength(255);

                entity.Property(e => e.BLFwd).HasMaxLength(255);

                entity.Property(e => e.BLIntCode).HasMaxLength(255);

                entity.Property(e => e.BLIntStartDate).HasColumnType("datetime");

                entity.Property(e => e.BLNumber).HasMaxLength(255);

                entity.Property(e => e.BPOFlag).HasMaxLength(255);

                entity.Property(e => e.BenCnty).HasMaxLength(255);

                entity.Property(e => e.BenInfo).HasMaxLength(255);

                entity.Property(e => e.BenName).HasMaxLength(255);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(255);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(255);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(255);

                entity.Property(e => e.CCS_LmType).HasMaxLength(255);

                entity.Property(e => e.CFRRate).HasMaxLength(255);

                entity.Property(e => e.Campaign_Code).HasMaxLength(255);

                entity.Property(e => e.Campaign_EffDate).HasMaxLength(255);

                entity.Property(e => e.ChipAcBank).HasMaxLength(255);

                entity.Property(e => e.ChipInterm).HasMaxLength(255);

                entity.Property(e => e.ChipNego).HasMaxLength(255);

                entity.Property(e => e.CommDesc).HasMaxLength(255);

                entity.Property(e => e.CommExch).HasMaxLength(255);

                entity.Property(e => e.CommFCD).HasMaxLength(255);

                entity.Property(e => e.CustAddr).HasMaxLength(255);

                entity.Property(e => e.CustCode).HasMaxLength(255);

                entity.Property(e => e.DAccruAmt).HasMaxLength(255);

                entity.Property(e => e.DMS).HasMaxLength(255);

                entity.Property(e => e.DateLastAccru).HasMaxLength(255);

                entity.Property(e => e.DateLastPaid).HasColumnType("datetime");

                entity.Property(e => e.DateStartAccru).HasColumnType("datetime");

                entity.Property(e => e.DateToStop).HasMaxLength(255);

                entity.Property(e => e.DocCCy).HasMaxLength(255);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.Event).HasMaxLength(255);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventFlag).HasMaxLength(255);

                entity.Property(e => e.EventMode).HasMaxLength(255);

                entity.Property(e => e.ExchBefore).HasMaxLength(255);

                entity.Property(e => e.FBCcy).HasMaxLength(255);

                entity.Property(e => e.FCyAcNo).HasMaxLength(255);

                entity.Property(e => e.FCyPayFlag).HasMaxLength(255);

                entity.Property(e => e.FCyReceiptNo).HasMaxLength(255);

                entity.Property(e => e.FacNo).HasMaxLength(255);

                entity.Property(e => e.GenAccFlag).HasMaxLength(255);

                entity.Property(e => e.Goods).HasMaxLength(255);

                entity.Property(e => e.InUse).HasMaxLength(255);

                entity.Property(e => e.IntBefore).HasMaxLength(255);

                entity.Property(e => e.IntFixDate).HasMaxLength(255);

                entity.Property(e => e.IntFlag).HasMaxLength(255);

                entity.Property(e => e.IntPayType).HasMaxLength(255);

                entity.Property(e => e.IntRateCode).HasMaxLength(255);

                entity.Property(e => e.IntStartDate).HasColumnType("datetime");

                entity.Property(e => e.IntermAddr).HasMaxLength(255);

                entity.Property(e => e.IntermBank).HasMaxLength(255);

                entity.Property(e => e.LCNumber).HasMaxLength(255);

                entity.Property(e => e.LOCode).HasMaxLength(255);

                entity.Property(e => e.LastAccruAmt).HasMaxLength(255);

                entity.Property(e => e.LastAccruCcy).HasMaxLength(255);

                entity.Property(e => e.LastIntAmt).HasMaxLength(255);

                entity.Property(e => e.LastIntDate).HasColumnType("datetime");

                entity.Property(e => e.LastReceiptNo).HasMaxLength(255);

                entity.Property(e => e.MTType).HasMaxLength(255);

                entity.Property(e => e.Nego799).HasMaxLength(255);

                entity.Property(e => e.Nego999).HasMaxLength(255);

                entity.Property(e => e.NegoBank).HasMaxLength(255);

                entity.Property(e => e.NegoCnty).HasMaxLength(255);

                entity.Property(e => e.NegoRefno).HasMaxLength(255);

                entity.Property(e => e.NegoTelex).HasMaxLength(255);

                entity.Property(e => e.NewAccruAmt).HasMaxLength(255);

                entity.Property(e => e.NewAccruCcy).HasMaxLength(255);

                entity.Property(e => e.NostACInfo).HasMaxLength(255);

                entity.Property(e => e.ObjectType).HasMaxLength(255);

                entity.Property(e => e.OverdueDate).HasMaxLength(255);

                entity.Property(e => e.PAccruAmt).HasMaxLength(255);

                entity.Property(e => e.PastDueDate).HasMaxLength(255);

                entity.Property(e => e.PayAmount).HasMaxLength(255);

                entity.Property(e => e.PayFlag).HasMaxLength(255);

                entity.Property(e => e.PayInterest).HasMaxLength(255);

                entity.Property(e => e.PayMethod).HasMaxLength(255);

                entity.Property(e => e.PayType).HasMaxLength(255);

                entity.Property(e => e.PrevDueDate).HasMaxLength(255);

                entity.Property(e => e.PrevFBChrg).HasMaxLength(255);

                entity.Property(e => e.PrevFBEng).HasMaxLength(255);

                entity.Property(e => e.PrevFBInt).HasMaxLength(255);

                entity.Property(e => e.RecStatus).HasMaxLength(255);

                entity.Property(e => e.RecType).HasMaxLength(255);

                entity.Property(e => e.RefNumber).HasMaxLength(255);

                entity.Property(e => e.ReimBank).HasMaxLength(255);

                entity.Property(e => e.Relation).HasMaxLength(255);

                entity.Property(e => e.RevAccru).HasMaxLength(255);

                entity.Property(e => e.RevAccruTax).HasMaxLength(255);

                entity.Property(e => e.SGNumber).HasMaxLength(255);

                entity.Property(e => e.SGNumber1).HasMaxLength(255);

                entity.Property(e => e.SettleDate).HasMaxLength(255);

                entity.Property(e => e.SettleFlag).HasMaxLength(255);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TRCCyFlag).HasMaxLength(255);

                entity.Property(e => e.TRCcy).HasMaxLength(255);

                entity.Property(e => e.TRCont1).HasMaxLength(255);

                entity.Property(e => e.TRCont2).HasMaxLength(255);

                entity.Property(e => e.TRCont3).HasMaxLength(255);

                entity.Property(e => e.TRCont4).HasMaxLength(255);

                entity.Property(e => e.TRCont5).HasMaxLength(255);

                entity.Property(e => e.TRDueStatus).HasMaxLength(255);

                entity.Property(e => e.TRFLAG).HasMaxLength(255);

                entity.Property(e => e.TRNumber).HasMaxLength(255);

                entity.Property(e => e.TRRate).HasMaxLength(255);

                entity.Property(e => e.TRStatus).HasMaxLength(255);

                entity.Property(e => e.TaxRefund).HasMaxLength(255);

                entity.Property(e => e.TenorType).HasMaxLength(255);

                entity.Property(e => e.Tx23E).HasMaxLength(255);

                entity.Property(e => e.Tx26).HasMaxLength(255);

                entity.Property(e => e.Tx59A).HasMaxLength(255);

                entity.Property(e => e.Tx59Cnty).HasMaxLength(255);

                entity.Property(e => e.Tx59D).HasMaxLength(255);

                entity.Property(e => e.Tx71A).HasMaxLength(255);

                entity.Property(e => e.Tx72).HasMaxLength(255);

                entity.Property(e => e.UnderlyName).HasMaxLength(255);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(255);

                entity.Property(e => e.ValueDate).HasMaxLength(255);
            });

            modelBuilder.Entity<pIMTR3>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pIMTR3");

                entity.Property(e => e.AuthDate).HasColumnType("datetime");

                entity.Property(e => e.AutoOverDue).HasMaxLength(255);

                entity.Property(e => e.BLIntStartDate).HasColumnType("datetime");

                entity.Property(e => e.BPOFlag).HasMaxLength(255);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("datetime");

                entity.Property(e => e.DMS).HasMaxLength(255);

                entity.Property(e => e.DateLastAccru).HasColumnType("datetime");

                entity.Property(e => e.DateLastPaid).HasColumnType("datetime");

                entity.Property(e => e.DateStartAccru).HasColumnType("datetime");

                entity.Property(e => e.DateToStop).HasColumnType("datetime");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventFlag).HasMaxLength(255);

                entity.Property(e => e.EventMode).HasMaxLength(255);

                entity.Property(e => e.FCyPayFlag).HasMaxLength(255);

                entity.Property(e => e.GenAccFlag).HasMaxLength(255);

                entity.Property(e => e.InUse).HasMaxLength(255);

                entity.Property(e => e.IntFlag).HasMaxLength(255);

                entity.Property(e => e.IntPayType).HasMaxLength(255);

                entity.Property(e => e.IntStartDate).HasColumnType("datetime");

                entity.Property(e => e.LastIntDate).HasColumnType("datetime");

                entity.Property(e => e.MTNego).HasMaxLength(255);

                entity.Property(e => e.MTType).HasMaxLength(255);

                entity.Property(e => e.Nego799).HasMaxLength(255);

                entity.Property(e => e.Nego999).HasMaxLength(255);

                entity.Property(e => e.NegoTelex).HasMaxLength(255);

                entity.Property(e => e.OverdueDate).HasColumnType("datetime");

                entity.Property(e => e.PastDueDate).HasColumnType("datetime");

                entity.Property(e => e.PayFlag).HasMaxLength(255);

                entity.Property(e => e.PayType).HasMaxLength(255);

                entity.Property(e => e.PrevDueDate).HasColumnType("datetime");

                entity.Property(e => e.RecStatus).HasMaxLength(255);

                entity.Property(e => e.RecType).HasMaxLength(255);

                entity.Property(e => e.SettleDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TRCCyFlag).HasMaxLength(255);

                entity.Property(e => e.TRDueStatus).HasMaxLength(255);

                entity.Property(e => e.TRFLAG).HasMaxLength(255);

                entity.Property(e => e.TRRate).HasMaxLength(255);

                entity.Property(e => e.TRStatus).HasMaxLength(255);

                entity.Property(e => e.TaxRefund).HasMaxLength(255);

                entity.Property(e => e.Tx26).HasMaxLength(255);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.ValueDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<pIMTRInvoice>(entity =>
            {
                entity.HasKey(e => new { e.CustCode, e.InvNumber, e.InvStatus });

                entity.ToTable("pIMTRInvoice");

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.InvNumber).HasMaxLength(26);

                entity.Property(e => e.InvStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.InvCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.InvDate).HasColumnType("smalldatetime");

                entity.Property(e => e.InvGroup).HasMaxLength(4);

                entity.Property(e => e.InvSupply).HasMaxLength(150);

                entity.Property(e => e.LastUpDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TRFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.UserDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pIMTRText>(entity =>
            {
                entity.HasKey(e => new { e.RefNumber, e.Seqno });

                entity.ToTable("pIMTRText");

                entity.Property(e => e.RefNumber).HasMaxLength(15);

                entity.Property(e => e.TRNumber).HasMaxLength(15);

                entity.Property(e => e.Text79).HasMaxLength(2100);

                entity.Property(e => e.Text79_1).HasMaxLength(2100);
            });

            modelBuilder.Entity<pInstall>(entity =>
            {
                entity.HasKey(e => new { e.LC_NO, e.SEQ_NO });

                entity.ToTable("pInstall");

                entity.Property(e => e.LC_NO).HasMaxLength(15);

                entity.Property(e => e.DUE_DATE).HasColumnType("datetime");
            });

            modelBuilder.Entity<pIntRate>(entity =>
            {
                entity.HasKey(e => new { e.IRate_Code, e.IRate_EffDate, e.IRate_EffTime })
                    .HasName("PK_pInterestRate");

                entity.ToTable("pIntRate");

                entity.Property(e => e.IRate_Code).HasMaxLength(10);

                entity.Property(e => e.IRate_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.IRate_EffTime)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("datetime");

                entity.Property(e => e.Batch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IRate_Rate).HasDefaultValueSql("((0))");

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<pLogBatch>(entity =>
            {
                entity.HasKey(e => e.RunDate);

                entity.ToTable("pLogBatch");

                entity.Property(e => e.RunDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AutoPastDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.CCSReve)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.GenAccru)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.GenAmort)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.GenBPOCam)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.GenFcd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.GenFloat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.GenMapSap)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.GenSapERP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.ImpMidRate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.LastTime).HasMaxLength(5);

                entity.Property(e => e.PostAccru)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.StartTime).HasMaxLength(5);

                entity.Property(e => e.SumSap)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<pLogFcdAccount>(entity =>
            {
                entity.HasKey(e => new { e.LogDate, e.LogTime });

                entity.ToTable("pLogFcdAccount");

                entity.Property(e => e.LogDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LogTime).HasMaxLength(8);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.LogComp).HasMaxLength(20);

                entity.Property(e => e.LogCust_Code).HasMaxLength(6);

                entity.Property(e => e.LogEvent).HasMaxLength(30);

                entity.Property(e => e.LogFcdAccNo).HasMaxLength(13);

                entity.Property(e => e.LogFcdRef).HasMaxLength(20);

                entity.Property(e => e.LogStatus).HasMaxLength(50);

                entity.Property(e => e.LogUser).HasMaxLength(12);
            });

            modelBuilder.Entity<pLogLoadText>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pLogLoadText");

                entity.Property(e => e.BatchName).HasMaxLength(20);

                entity.Property(e => e.EndTime).HasColumnType("smalldatetime");

                entity.Property(e => e.LoadDate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StartTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<pLogUser>(entity =>
            {
                entity.HasKey(e => new { e.LogDate, e.LogTime, e.SeqNo, e.UserCode })
                    .HasName("PK_pLogIn");

                entity.ToTable("pLogUser");

                entity.Property(e => e.LogDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LogTime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.ComName).HasMaxLength(20);

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<pLog_Connect1P>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pLog_Connect1P");

                entity.Property(e => e.ACNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ACType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AcName).HasMaxLength(50);

                entity.Property(e => e.OnePReturn).HasMaxLength(100);

                entity.Property(e => e.RqAPPHeader).HasMaxLength(106);

                entity.Property(e => e.RqDSPHeader).HasMaxLength(312);

                entity.Property(e => e.RqDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RqDetail).HasMaxLength(1284);

                entity.Property(e => e.RqTime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RsDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RsMsg).HasMaxLength(2048);

                entity.Property(e => e.RsTime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SumLog).HasMaxLength(50);

                entity.Property(e => e.TrEvent)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TrRefSeq)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TrType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UserID).HasMaxLength(12);
            });

            modelBuilder.Entity<pLog_CustLiab>(entity =>
            {
                entity.HasKey(e => new { e.LogDate, e.LogTime, e.LogUser, e.LogRec, e.Cust_Code, e.Facility_No, e.Currency });

                entity.ToTable("pLog_CustLiab");

                entity.Property(e => e.LogDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LogTime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LogUser).HasMaxLength(12);

                entity.Property(e => e.LogRec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.Facility_No).HasMaxLength(13);

                entity.Property(e => e.Currency).HasMaxLength(3);

                entity.Property(e => e.EXPC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.EXPC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLS_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLS_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLT_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IBLT_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMBL_Over).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMLC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMLC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMTR_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IMTR_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.NLTR_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGBC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGBC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGLC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.SGLC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.XBCC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCP_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XBCP_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCC_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCC_Book).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCP_Amt).HasDefaultValueSql("((0))");

                entity.Property(e => e.XLCP_Book).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<pLog_ErrorConnect1P>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pLog_ErrorConnect1P");

                entity.Property(e => e.ACNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ACType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ErrMsg).HasMaxLength(700);

                entity.Property(e => e.OnePReturn).HasMaxLength(100);

                entity.Property(e => e.RqDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RqTime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SumLog).HasMaxLength(50);

                entity.Property(e => e.TrEvent)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TrRefSeq)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TrType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UserID).HasMaxLength(12);
            });

            modelBuilder.Entity<pLog_ImportCB>(entity =>
            {
                entity.HasKey(e => new { e.PostDate, e.LogFileName });

                entity.ToTable("pLog_ImportCBS");

                entity.Property(e => e.PostDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LogFileName).HasMaxLength(100);

                entity.Property(e => e.LogDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LogReDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LogReUser).HasMaxLength(8);

                entity.Property(e => e.LogRerun)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LogStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<pLog_MainConnect1P>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pLog_MainConnect1P");

                entity.Property(e => e.ACNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ACType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AcName).HasMaxLength(50);

                entity.Property(e => e.OnePReturn).HasMaxLength(100);

                entity.Property(e => e.RqDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RqTime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RsDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RsTime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SumLog).HasMaxLength(50);

                entity.Property(e => e.TrEvent)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TrRefSeq)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TrType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UserID).HasMaxLength(12);
            });

            modelBuilder.Entity<pLog_MasterOut>(entity =>
            {
                entity.HasKey(e => new { e.LogDate, e.LogTime, e.LogUser, e.Module, e.KeyNumber });

                entity.ToTable("pLog_MasterOut");

                entity.Property(e => e.LogDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LogTime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LogUser).HasMaxLength(12);

                entity.Property(e => e.Module).HasMaxLength(5);

                entity.Property(e => e.KeyNumber).HasMaxLength(15);

                entity.Property(e => e.CCy).HasMaxLength(3);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.FlagDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastEvent).HasMaxLength(25);

                entity.Property(e => e.LastPayment).HasColumnType("smalldatetime");

                entity.Property(e => e.Reference).HasMaxLength(20);
            });

            modelBuilder.Entity<pLog_QueryAC1P>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pLog_QueryAC1P");

                entity.Property(e => e.ACNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ACType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.OnePReturn).HasMaxLength(100);

                entity.Property(e => e.RqAPPHeader).HasMaxLength(106);

                entity.Property(e => e.RqDSPHeader).HasMaxLength(312);

                entity.Property(e => e.RqDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RqDetail).HasMaxLength(1284);

                entity.Property(e => e.RqTime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RsACName).HasMaxLength(50);

                entity.Property(e => e.RsDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RsMsg).HasMaxLength(2048);

                entity.Property(e => e.RsTime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SumLog).HasMaxLength(50);
            });

            modelBuilder.Entity<pLog_Request1P>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pLog_Request1P");

                entity.Property(e => e.ACNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ACType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TrEvent)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TrRefSeq)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TrRqDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TrType)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<pLog_SendMail>(entity =>
            {
                entity.HasKey(e => new { e.SendDate, e.SendTime })
                    .HasName("PK_pLogSendMail");

                entity.ToTable("pLog_SendMail");

                entity.Property(e => e.SendDate).HasColumnType("smalldatetime");

                entity.Property(e => e.SendTime).HasMaxLength(8);

                entity.Property(e => e.Response).HasMaxLength(500);

                entity.Property(e => e.SendBCC).HasMaxLength(300);

                entity.Property(e => e.SendCC).HasMaxLength(300);

                entity.Property(e => e.SendFile1).HasMaxLength(100);

                entity.Property(e => e.SendFile2).HasMaxLength(100);

                entity.Property(e => e.SendFile3).HasMaxLength(100);

                entity.Property(e => e.SendFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SendMod).HasMaxLength(10);

                entity.Property(e => e.SendPass).HasMaxLength(100);

                entity.Property(e => e.SendSJB).HasMaxLength(500);

                entity.Property(e => e.SendTO).HasMaxLength(300);

                entity.Property(e => e.SendUser).HasMaxLength(12);
            });

            modelBuilder.Entity<pLog_SendMail1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pLog_SendMail1");

                entity.Property(e => e.Response).HasMaxLength(500);

                entity.Property(e => e.SendBCC).HasMaxLength(300);

                entity.Property(e => e.SendCC).HasMaxLength(300);

                entity.Property(e => e.SendDate).HasColumnType("smalldatetime");

                entity.Property(e => e.SendFile1).HasMaxLength(100);

                entity.Property(e => e.SendFile2).HasMaxLength(100);

                entity.Property(e => e.SendFile3).HasMaxLength(100);

                entity.Property(e => e.SendMod).HasMaxLength(10);

                entity.Property(e => e.SendSJB).HasMaxLength(500);

                entity.Property(e => e.SendTO).HasMaxLength(300);

                entity.Property(e => e.SendTime).HasMaxLength(8);

                entity.Property(e => e.SendUser).HasMaxLength(12);
            });

            modelBuilder.Entity<pLog_Swift>(entity =>
            {
                entity.HasKey(e => new { e.FileName, e.RefNo, e.SeqNo });

                entity.ToTable("pLog_Swift");

                entity.Property(e => e.FileName).HasMaxLength(35);

                entity.Property(e => e.RefNo).HasMaxLength(16);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ErrCode).HasMaxLength(20);

                entity.Property(e => e.Event).HasMaxLength(25);

                entity.Property(e => e.LoadDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LoadFile).HasMaxLength(100);

                entity.Property(e => e.Login).HasMaxLength(5);

                entity.Property(e => e.Resend)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SendDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Status).HasMaxLength(3);

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<pLog_SwiftInDetail>(entity =>
            {
                entity.HasKey(e => new { e.FileName, e.SwiftInID, e.SwiftInType, e.RunLineNo });

                entity.ToTable("pLog_SwiftInDetail");

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.Property(e => e.SwiftInID).HasMaxLength(30);

                entity.Property(e => e.SwiftInType).HasMaxLength(3);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FieldNo).HasMaxLength(6);

                entity.Property(e => e.LoadDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pLog_SwiftInFile>(entity =>
            {
                entity.HasKey(e => new { e.FileName, e.FileDate });

                entity.ToTable("pLog_SwiftInFile");

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.Property(e => e.FileDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LoadDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LoadStatus).HasMaxLength(20);
            });

            modelBuilder.Entity<pLog_SwiftInHead>(entity =>
            {
                entity.HasKey(e => e.SwiftInID)
                    .HasName("PK_pLog_SwiftHead");

                entity.ToTable("pLog_SwiftInHead");

                entity.Property(e => e.SwiftInID).HasMaxLength(30);

                entity.Property(e => e.FromBank).HasMaxLength(13);

                entity.Property(e => e.Head1).HasMaxLength(60);

                entity.Property(e => e.Head2).HasMaxLength(60);

                entity.Property(e => e.Head3).HasMaxLength(150);

                entity.Property(e => e.SwiftInType).HasMaxLength(3);
            });

            modelBuilder.Entity<pLog_SwiftR>(entity =>
            {
                entity.HasKey(e => new { e.FileName, e.FileDate });

                entity.ToTable("pLog_SwiftRS");

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.Property(e => e.FileDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LoadDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LoadStatus).HasMaxLength(10);
            });

            modelBuilder.Entity<pLog_UnlockDoc>(entity =>
            {
                entity.HasKey(e => new { e.UnDate, e.UnTime });

                entity.ToTable("pLog_UnlockDoc");

                entity.Property(e => e.UnDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UnTime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UnDetail).HasMaxLength(500);

                entity.Property(e => e.UnFunc).HasMaxLength(100);

                entity.Property(e => e.UnRefNo).HasMaxLength(15);

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<pMISCTran>(entity =>
            {
                entity.HasKey(e => new { e.Login, e.RefNumber, e.Seqno });

                entity.ToTable("pMISCTran");

                entity.Property(e => e.Login).HasMaxLength(4);

                entity.Property(e => e.RefNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AcAddr).HasMaxLength(144);

                entity.Property(e => e.AcBank).HasMaxLength(14);

                entity.Property(e => e.Allocation).HasMaxLength(10);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.BenAddr).HasMaxLength(144);

                entity.Property(e => e.BenBank).HasMaxLength(14);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.ChipAcBank).HasMaxLength(14);

                entity.Property(e => e.ChipBenBank).HasMaxLength(14);

                entity.Property(e => e.ChipInterm).HasMaxLength(14);

                entity.Property(e => e.CustAddr).HasMaxLength(144);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.Cust_Bran).HasMaxLength(3);

                entity.Property(e => e.DMS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DateGenAc).HasColumnType("smalldatetime");

                entity.Property(e => e.DateLastPaid).HasColumnType("smalldatetime");

                entity.Property(e => e.DocCcy).HasMaxLength(3);

                entity.Property(e => e.DocCommCcy).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DocNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Event).HasMaxLength(25);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventFlag)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FBCcy).HasMaxLength(3);

                entity.Property(e => e.FCDAcNo).HasMaxLength(15);

                entity.Property(e => e.FCDReceiptNo).HasMaxLength(15);

                entity.Property(e => e.GenAccFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntermAddr).HasMaxLength(144);

                entity.Property(e => e.IntermBank).HasMaxLength(14);

                entity.Property(e => e.LastReceiptNo).HasMaxLength(15);

                entity.Property(e => e.MTType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayMethod).HasMaxLength(15);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReimBank).HasMaxLength(14);

                entity.Property(e => e.ReimRefNo).HasMaxLength(16);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.TaxRefund)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Tx72).HasMaxLength(432);

                entity.Property(e => e.Tx79).HasMaxLength(2100);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.VoucherID).HasMaxLength(15);
            });

            modelBuilder.Entity<pMasterDailyOut>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CCy).HasMaxLength(3);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.FlagDue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.GFBCInt).HasMaxLength(10);

                entity.Property(e => e.GFBCOuts).HasMaxLength(10);

                entity.Property(e => e.GFMSAccInt).HasMaxLength(11);

                entity.Property(e => e.GFMSAccOuts).HasMaxLength(11);

                entity.Property(e => e.GFMSBran).HasMaxLength(4);

                entity.Property(e => e.KeyNumber).HasMaxLength(15);

                entity.Property(e => e.LastEvent).HasMaxLength(25);

                entity.Property(e => e.LastPayment).HasColumnType("smalldatetime");

                entity.Property(e => e.LiabType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Module).HasMaxLength(5);

                entity.Property(e => e.OutsDate).HasMaxLength(10);

                entity.Property(e => e.OverdueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PastDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ProdCode).HasMaxLength(5);

                entity.Property(e => e.RCCode).HasMaxLength(5);

                entity.Property(e => e.RMCode).HasMaxLength(10);

                entity.Property(e => e.Reference).HasMaxLength(50);

                entity.Property(e => e.SBUCode).HasMaxLength(5);

                entity.Property(e => e.SubProduct).HasMaxLength(5);

                entity.Property(e => e.TENOR_TYPE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenorDay).HasMaxLength(4);

                entity.Property(e => e.TenorType).HasMaxLength(20);

                entity.Property(e => e.WithOutFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.WithOutType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<pMasterDailyOuts1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pMasterDailyOuts1");

                entity.Property(e => e.AccruCcy).HasMaxLength(255);

                entity.Property(e => e.AccruPending).HasMaxLength(255);

                entity.Property(e => e.BalanceAmt).HasMaxLength(255);

                entity.Property(e => e.CCy).HasMaxLength(255);

                entity.Property(e => e.CustCode).HasMaxLength(255);

                entity.Property(e => e.FlagDue).HasMaxLength(255);

                entity.Property(e => e.GFBCInt).HasMaxLength(255);

                entity.Property(e => e.GFBCOuts).HasMaxLength(255);

                entity.Property(e => e.GFMSAccInt).HasMaxLength(255);

                entity.Property(e => e.GFMSAccOuts).HasMaxLength(255);

                entity.Property(e => e.GFMSBran).HasMaxLength(255);

                entity.Property(e => e.KeyNumber).HasMaxLength(255);

                entity.Property(e => e.LastEvent).HasMaxLength(255);

                entity.Property(e => e.LastPayment).HasMaxLength(255);

                entity.Property(e => e.LiabType).HasMaxLength(255);

                entity.Property(e => e.Module).HasMaxLength(255);

                entity.Property(e => e.OriginalAmt).HasMaxLength(255);

                entity.Property(e => e.OutsDate).HasMaxLength(255);

                entity.Property(e => e.OverdueDate).HasMaxLength(255);

                entity.Property(e => e.PastDueDate).HasMaxLength(255);

                entity.Property(e => e.ProdCode).HasMaxLength(255);

                entity.Property(e => e.RCCode).HasMaxLength(255);

                entity.Property(e => e.RMCode).HasMaxLength(255);

                entity.Property(e => e.Reference).HasMaxLength(255);

                entity.Property(e => e.RevAccru).HasMaxLength(255);

                entity.Property(e => e.SBUCode).HasMaxLength(255);

                entity.Property(e => e.SubProduct).HasMaxLength(255);

                entity.Property(e => e.TENOR_TYPE).HasMaxLength(255);

                entity.Property(e => e.TenorDay).HasMaxLength(255);

                entity.Property(e => e.TenorType).HasMaxLength(255);

                entity.Property(e => e.WithOutFlag).HasMaxLength(255);

                entity.Property(e => e.WithOutType).HasMaxLength(255);

                entity.Property(e => e.intRate).HasMaxLength(255);
            });

            modelBuilder.Entity<pMasterDailyOuts2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pMasterDailyOuts2");

                entity.Property(e => e.FlagDue).HasMaxLength(255);

                entity.Property(e => e.LastPayment).HasColumnType("datetime");

                entity.Property(e => e.LiabType).HasMaxLength(255);

                entity.Property(e => e.OverdueDate).HasColumnType("datetime");

                entity.Property(e => e.PastDueDate).HasColumnType("datetime");

                entity.Property(e => e.TENOR_TYPE).HasMaxLength(255);

                entity.Property(e => e.WithOutFlag).HasMaxLength(255);

                entity.Property(e => e.WithOutType).HasMaxLength(255);
            });

            modelBuilder.Entity<pMidRate>(entity =>
            {
                entity.HasKey(e => new { e.Rate_Date, e.Rate_Time, e.Rate_Ccy });

                entity.ToTable("pMidRate");

                entity.Property(e => e.Rate_Date).HasColumnType("smalldatetime");

                entity.Property(e => e.Rate_Time)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Rate_Ccy).HasMaxLength(3);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("datetime");

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<pMonAccrued>(entity =>
            {
                entity.HasKey(e => new { e.Login, e.DocNo, e.DocMode, e.Seqno })
                    .HasName("PK_pAccrInterest");

                entity.ToTable("pMonAccrued");

                entity.Property(e => e.Login).HasMaxLength(4);

                entity.Property(e => e.DocNo).HasMaxLength(15);

                entity.Property(e => e.DocMode).HasMaxLength(20);

                entity.Property(e => e.BankType).HasMaxLength(14);

                entity.Property(e => e.CalDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.DocBank).HasMaxLength(14);

                entity.Property(e => e.DocCust).HasMaxLength(6);

                entity.Property(e => e.DocNumber).HasMaxLength(15);

                entity.Property(e => e.DocRefer).HasMaxLength(15);

                entity.Property(e => e.GenAccFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntCode).HasMaxLength(10);

                entity.Property(e => e.IntFrom).HasColumnType("smalldatetime");

                entity.Property(e => e.IntTo).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pMonCustInvoice>(entity =>
            {
                entity.HasKey(e => new { e.DocMon, e.DocMod, e.KeyNumber })
                    .HasName("PK_pTmpInvoice");

                entity.ToTable("pMonCustInvoice");

                entity.Property(e => e.DocMon).HasMaxLength(7);

                entity.Property(e => e.DocMod).HasMaxLength(4);

                entity.Property(e => e.KeyNumber).HasMaxLength(15);

                entity.Property(e => e.CCy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CalDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.DocNumer).HasMaxLength(20);

                entity.Property(e => e.DocType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FromDate).HasColumnType("smalldatetime");

                entity.Property(e => e.IntFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastRunDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RptFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ToDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pMonthlyInterest>(entity =>
            {
                entity.HasKey(e => new { e.DocMonth, e.DocSeq });

                entity.ToTable("pMonthlyInterest");

                entity.Property(e => e.DocMonth).HasMaxLength(7);

                entity.Property(e => e.ATSCode).HasMaxLength(2);

                entity.Property(e => e.ATSDate).HasColumnType("smalldatetime");

                entity.Property(e => e.BatchType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CalDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DebitACC).HasMaxLength(15);

                entity.Property(e => e.DocCcy).HasMaxLength(3);

                entity.Property(e => e.DocCust).HasMaxLength(6);

                entity.Property(e => e.DocNumber).HasMaxLength(15);

                entity.Property(e => e.DocRefer).HasMaxLength(15);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.IntCode).HasMaxLength(10);

                entity.Property(e => e.IntFrom).HasColumnType("smalldatetime");

                entity.Property(e => e.IntTo).HasColumnType("smalldatetime");

                entity.Property(e => e.Login).HasMaxLength(4);

                entity.Property(e => e.SendFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpReceipt).HasMaxLength(15);
            });

            modelBuilder.Entity<pONLUnMatchCust>(entity =>
            {
                entity.HasKey(e => new { e.ACCESS_ID, e.Trade_ref_Number, e.Edition_Number })
                    .HasName("PK_pMatchCustSucess");

                entity.ToTable("pONLUnMatchCust");

                entity.Property(e => e.ACCESS_ID)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Trade_ref_Number)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Edition_Number)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CIF)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<pPayDetail>(entity =>
            {
                entity.HasKey(e => new { e.DpReceiptNo, e.DpSeq });

                entity.ToTable("pPayDetail");

                entity.Property(e => e.DpReceiptNo).HasMaxLength(15);

                entity.Property(e => e.DpContract).HasMaxLength(20);

                entity.Property(e => e.DpFromDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DpPayName).HasMaxLength(80);

                entity.Property(e => e.DpRemark).HasMaxLength(200);

                entity.Property(e => e.DpToDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pPayment>(entity =>
            {
                entity.HasKey(e => e.RpReceiptNo);

                entity.ToTable("pPayment");

                entity.Property(e => e.RpReceiptNo).HasMaxLength(15);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RpApplicant).HasMaxLength(70);

                entity.Property(e => e.RpChqBank).HasMaxLength(10);

                entity.Property(e => e.RpChqBranch).HasMaxLength(25);

                entity.Property(e => e.RpChqNo).HasMaxLength(15);

                entity.Property(e => e.RpCustAc1).HasMaxLength(15);

                entity.Property(e => e.RpCustAc2).HasMaxLength(15);

                entity.Property(e => e.RpCustAc3).HasMaxLength(15);

                entity.Property(e => e.RpCustCode).HasMaxLength(6);

                entity.Property(e => e.RpDocNo).HasMaxLength(15);

                entity.Property(e => e.RpEvent).HasMaxLength(20);

                entity.Property(e => e.RpIssBank).HasMaxLength(70);

                entity.Property(e => e.RpModule).HasMaxLength(5);

                entity.Property(e => e.RpNote).HasMaxLength(200);

                entity.Property(e => e.RpPayBy).HasMaxLength(15);

                entity.Property(e => e.RpPayDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RpPrint)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RpRecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RpRefer1).HasMaxLength(70);

                entity.Property(e => e.RpRefer2).HasMaxLength(70);

                entity.Property(e => e.RpStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<pReferenceNo>(entity =>
            {
                entity.HasKey(e => new { e.pRefTrans, e.pRefBran, e.pRefYear, e.pRefPrefix });

                entity.ToTable("pReferenceNo");

                entity.Property(e => e.pRefTrans).HasMaxLength(6);

                entity.Property(e => e.pRefBran).HasMaxLength(4);

                entity.Property(e => e.pRefYear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.pRefPrefix).HasMaxLength(5);

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.pRefSeq).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<pRefinance>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pRefinance");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CustCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReFinance_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<pRemCleanBill>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pRemCleanBill");

                entity.Property(e => e.AgentName).HasMaxLength(500);

                entity.Property(e => e.Allocation).HasMaxLength(10);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.BankType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CICDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CLCCy).HasMaxLength(3);

                entity.Property(e => e.CLNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.ChqBank).HasMaxLength(10);

                entity.Property(e => e.ChqBranch).HasMaxLength(25);

                entity.Property(e => e.ChqNo).HasMaxLength(15);

                entity.Property(e => e.CollectBank).HasMaxLength(20);

                entity.Property(e => e.Collect_Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Cust_AC1).HasMaxLength(15);

                entity.Property(e => e.Cust_AC2).HasMaxLength(15);

                entity.Property(e => e.Cust_AC3).HasMaxLength(15);

                entity.Property(e => e.Cust_Addr).HasMaxLength(500);

                entity.Property(e => e.Cust_Bran).HasMaxLength(3);

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.Cust_Info).HasMaxLength(35);

                entity.Property(e => e.DateGenAcc).HasColumnType("smalldatetime");

                entity.Property(e => e.DatePaid).HasColumnType("smalldatetime");

                entity.Property(e => e.Description).HasMaxLength(15);

                entity.Property(e => e.Event).HasMaxLength(20);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FCDACNo).HasMaxLength(75);

                entity.Property(e => e.FCDRecNo).HasMaxLength(15);

                entity.Property(e => e.GenAccFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.InUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MixPayment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayMethod).HasMaxLength(25);

                entity.Property(e => e.PaySubType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RateType).HasMaxLength(1);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ReceiptNo).HasMaxLength(15);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.Result_Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TaxRefund)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TranResult).HasMaxLength(15);

                entity.Property(e => e.TranStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.VoucherID).HasMaxLength(15);
            });

            modelBuilder.Entity<pRemCleanBillCCY>(entity =>
            {
                entity.HasKey(e => new { e.CLNumber, e.RecType, e.SeqNo, e.BranCode })
                    .IsClustered(false);

                entity.ToTable("pRemCleanBillCCY");

                entity.Property(e => e.CLNumber).HasMaxLength(15);

                entity.Property(e => e.RecType).HasMaxLength(10);

                entity.Property(e => e.BranCode).HasMaxLength(3);

                entity.Property(e => e.CICDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Description).HasMaxLength(15);
            });

            modelBuilder.Entity<pRemPartial>(entity =>
            {
                entity.HasKey(e => new { e.RemRefNo, e.SeqNo });

                entity.ToTable("pRemPartial");

                entity.Property(e => e.RemRefNo).HasMaxLength(16);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.RmForward).HasMaxLength(15);
            });

            modelBuilder.Entity<pRemSWMap>(entity =>
            {
                entity.HasKey(e => e.SwifInID);

                entity.ToTable("pRemSWMap");

                entity.Property(e => e.SwifInID).HasMaxLength(50);

                entity.Property(e => e.CCY).HasMaxLength(3);

                entity.Property(e => e.FLag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Sender).HasMaxLength(15);

                entity.Property(e => e.SenderName).HasMaxLength(145);

                entity.Property(e => e.SwiftDate).HasColumnType("smalldatetime");

                entity.Property(e => e.SwiftMT)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Tag20).HasMaxLength(16);

                entity.Property(e => e.Tag50).HasMaxLength(35);

                entity.Property(e => e.Tag50D).HasMaxLength(145);

                entity.Property(e => e.Tag52).HasMaxLength(145);

                entity.Property(e => e.Tag53).HasMaxLength(15);

                entity.Property(e => e.Tag54).HasMaxLength(15);

                entity.Property(e => e.Tag57).HasMaxLength(145);

                entity.Property(e => e.Tag59).HasMaxLength(35);

                entity.Property(e => e.Tag59D).HasMaxLength(145);

                entity.Property(e => e.Tag70).HasMaxLength(145);

                entity.Property(e => e.VaDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pRemit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pRemit");

                entity.Property(e => e.Addr53).HasMaxLength(144);

                entity.Property(e => e.Addr54).HasMaxLength(144);

                entity.Property(e => e.Addr56).HasMaxLength(144);

                entity.Property(e => e.Addr57).HasMaxLength(144);

                entity.Property(e => e.Addr58).HasMaxLength(144);

                entity.Property(e => e.Allocation).HasMaxLength(15);

                entity.Property(e => e.AppInfo1).HasMaxLength(35);

                entity.Property(e => e.AppInfo2).HasMaxLength(35);

                entity.Property(e => e.AppInfo3).HasMaxLength(35);

                entity.Property(e => e.AppInfo4).HasMaxLength(35);

                entity.Property(e => e.AppvNo).HasMaxLength(13);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Bank53).HasMaxLength(14);

                entity.Property(e => e.Bank54).HasMaxLength(14);

                entity.Property(e => e.Bank56).HasMaxLength(14);

                entity.Property(e => e.Bank57).HasMaxLength(14);

                entity.Property(e => e.Bank58).HasMaxLength(14);

                entity.Property(e => e.BhtNet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.CustInfo1).HasMaxLength(35);

                entity.Property(e => e.CustInfo2).HasMaxLength(140);

                entity.Property(e => e.Cust_AO).HasMaxLength(5);

                entity.Property(e => e.Cust_Bran).HasMaxLength(3);

                entity.Property(e => e.Cust_CCID).HasMaxLength(8);

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.Cust_LO).HasMaxLength(8);

                entity.Property(e => e.DMS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DateGenAcc).HasColumnType("smalldatetime");

                entity.Property(e => e.DatePaid).HasColumnType("smalldatetime");

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.F20).HasMaxLength(16);

                entity.Property(e => e.F21).HasMaxLength(16);

                entity.Property(e => e.F23E).HasMaxLength(4);

                entity.Property(e => e.F26).HasMaxLength(3);

                entity.Property(e => e.F32A).HasMaxLength(28);

                entity.Property(e => e.F33B).HasMaxLength(28);

                entity.Property(e => e.F70).HasMaxLength(140);

                entity.Property(e => e.F71A).HasMaxLength(10);

                entity.Property(e => e.F71F).HasMaxLength(19);

                entity.Property(e => e.F72).HasMaxLength(432);

                entity.Property(e => e.F79).HasMaxLength(2100);

                entity.Property(e => e.FCDDesc).HasMaxLength(75);

                entity.Property(e => e.FCDRecNo).HasMaxLength(15);

                entity.Property(e => e.GenAccFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.GoodsCode).HasMaxLength(3);

                entity.Property(e => e.GoodsDesc).HasMaxLength(500);

                entity.Property(e => e.InUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT103)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT202)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayMainType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayMethod).HasMaxLength(15);

                entity.Property(e => e.PaySubType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PurposeCode).HasMaxLength(6);

                entity.Property(e => e.RateType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReceiptNo).HasMaxLength(15);

                entity.Property(e => e.RegistDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Rel_Code).HasMaxLength(6);

                entity.Property(e => e.RemAcc).HasMaxLength(35);

                entity.Property(e => e.RemAddr).HasMaxLength(144);

                entity.Property(e => e.RemBank)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.RemBankRefNo).HasMaxLength(20);

                entity.Property(e => e.RemCcy).HasMaxLength(3);

                entity.Property(e => e.RemDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RemRefNo)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.RemStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RemType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RmForward).HasMaxLength(15);

                entity.Property(e => e.SenderInfo).HasMaxLength(500);

                entity.Property(e => e.SwiftInfo).HasMaxLength(500);

                entity.Property(e => e.TaxRefund)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UID56).HasMaxLength(10);

                entity.Property(e => e.UID57).HasMaxLength(10);

                entity.Property(e => e.UID58).HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.VoucherID).HasMaxLength(15);
            });

            modelBuilder.Entity<pRemitBill>(entity =>
            {
                entity.HasKey(e => new { e.RemTranNo, e.RecType, e.SeqNo });

                entity.ToTable("pRemitBill");

                entity.Property(e => e.RemTranNo).HasMaxLength(15);

                entity.Property(e => e.RecType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Addr53).HasMaxLength(144);

                entity.Property(e => e.Addr54).HasMaxLength(144);

                entity.Property(e => e.Allocation).HasMaxLength(10);

                entity.Property(e => e.AppInfo).HasMaxLength(140);

                entity.Property(e => e.AppRefNo).HasMaxLength(35);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Bank53).HasMaxLength(14);

                entity.Property(e => e.Bank54).HasMaxLength(14);

                entity.Property(e => e.BankRefNo).HasMaxLength(20);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.CollectBank).HasMaxLength(14);

                entity.Property(e => e.CustInfo1).HasMaxLength(35);

                entity.Property(e => e.CustInfo2).HasMaxLength(140);

                entity.Property(e => e.Cust_AO).HasMaxLength(5);

                entity.Property(e => e.Cust_Bran).HasMaxLength(3);

                entity.Property(e => e.Cust_CCID).HasMaxLength(8);

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.DMS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DateGenAcc).HasColumnType("smalldatetime");

                entity.Property(e => e.DatePaid).HasColumnType("smalldatetime");

                entity.Property(e => e.Event).HasMaxLength(20);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.F20).HasMaxLength(16);

                entity.Property(e => e.F21).HasMaxLength(16);

                entity.Property(e => e.F23E).HasMaxLength(4);

                entity.Property(e => e.F26).HasMaxLength(3);

                entity.Property(e => e.F30).HasMaxLength(13);

                entity.Property(e => e.F32A).HasMaxLength(19);

                entity.Property(e => e.F59).HasMaxLength(144);

                entity.Property(e => e.FCDACNo).HasMaxLength(75);

                entity.Property(e => e.FCDRecNo).HasMaxLength(15);

                entity.Property(e => e.ForwardNo).HasMaxLength(15);

                entity.Property(e => e.GenAccFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.GoodsCode).HasMaxLength(3);

                entity.Property(e => e.GoodsDesc).HasMaxLength(500);

                entity.Property(e => e.InUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT110)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MixPayment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayMethod).HasMaxLength(15);

                entity.Property(e => e.PaySubType).HasMaxLength(1);

                entity.Property(e => e.PrevRefNo).HasMaxLength(35);

                entity.Property(e => e.PurposeCode).HasMaxLength(6);

                entity.Property(e => e.RateType).HasMaxLength(1);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReceiptNo).HasMaxLength(15);

                entity.Property(e => e.RelateCode).HasMaxLength(6);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.RmCcy).HasMaxLength(3);

                entity.Property(e => e.TaxRefund)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TranAddr).HasMaxLength(144);

                entity.Property(e => e.TranBank)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.TranResult).HasMaxLength(15);

                entity.Property(e => e.TranStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TranType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UID53).HasMaxLength(10);

                entity.Property(e => e.UID54).HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.ValueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.VoucherID).HasMaxLength(15);
            });

            modelBuilder.Entity<pRemittance>(entity =>
            {
                entity.HasKey(e => e.RemRefNo);

                entity.ToTable("pRemittance");

                entity.Property(e => e.RemRefNo).HasMaxLength(15);

                entity.Property(e => e.Addr52).HasMaxLength(148);

                entity.Property(e => e.Addr53).HasMaxLength(148);

                entity.Property(e => e.Addr54).HasMaxLength(148);

                entity.Property(e => e.Addr56).HasMaxLength(148);

                entity.Property(e => e.Addr57).HasMaxLength(148);

                entity.Property(e => e.Addr58).HasMaxLength(185);

                entity.Property(e => e.Allocation).HasMaxLength(15);

                entity.Property(e => e.AppInfo1).HasMaxLength(35);

                entity.Property(e => e.AppInfo2).HasMaxLength(35);

                entity.Property(e => e.AppInfo3).HasMaxLength(35);

                entity.Property(e => e.AppInfo4).HasMaxLength(35);

                entity.Property(e => e.AppvNo).HasMaxLength(13);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Bank52).HasMaxLength(14);

                entity.Property(e => e.Bank53).HasMaxLength(14);

                entity.Property(e => e.Bank53B).HasMaxLength(34);

                entity.Property(e => e.Bank54).HasMaxLength(14);

                entity.Property(e => e.Bank54B).HasMaxLength(34);

                entity.Property(e => e.Bank56).HasMaxLength(14);

                entity.Property(e => e.Bank57).HasMaxLength(14);

                entity.Property(e => e.Bank58).HasMaxLength(14);

                entity.Property(e => e.BhtNet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CF50)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CF59)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.Cov202)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CustInfo1).HasMaxLength(35);

                entity.Property(e => e.CustInfo2).HasMaxLength(140);

                entity.Property(e => e.Cust_AO).HasMaxLength(5);

                entity.Property(e => e.Cust_Bran).HasMaxLength(3);

                entity.Property(e => e.Cust_CCID).HasMaxLength(8);

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.Cust_LO).HasMaxLength(8);

                entity.Property(e => e.DMS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.DateGenAcc).HasColumnType("smalldatetime");

                entity.Property(e => e.DatePaid).HasColumnType("smalldatetime");

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ExchRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.F20).HasMaxLength(16);

                entity.Property(e => e.F21).HasMaxLength(16);

                entity.Property(e => e.F23E).HasMaxLength(4);

                entity.Property(e => e.F26).HasMaxLength(3);

                entity.Property(e => e.F32A).HasMaxLength(28);

                entity.Property(e => e.F33B).HasMaxLength(28);

                entity.Property(e => e.F50K).HasMaxLength(148);

                entity.Property(e => e.F59).HasMaxLength(148);

                entity.Property(e => e.F70).HasMaxLength(148);

                entity.Property(e => e.F71A).HasMaxLength(10);

                entity.Property(e => e.F71Adch).HasMaxLength(50);

                entity.Property(e => e.F71F).HasMaxLength(19);

                entity.Property(e => e.F72).HasMaxLength(222);

                entity.Property(e => e.FCDDesc).HasMaxLength(75);

                entity.Property(e => e.FCDRecNo).HasMaxLength(15);

                entity.Property(e => e.GenAccFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.GoodsCode).HasMaxLength(3);

                entity.Property(e => e.GoodsDesc).HasMaxLength(500);

                entity.Property(e => e.InUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT103)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT202)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayMainType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayMethod).HasMaxLength(15);

                entity.Property(e => e.PaySubType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PurposeCode).HasMaxLength(6);

                entity.Property(e => e.RateFlag).HasMaxLength(50);

                entity.Property(e => e.RateRemark).HasMaxLength(50);

                entity.Property(e => e.RateType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReceiptNo).HasMaxLength(15);

                entity.Property(e => e.RegistDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Rel_Code).HasMaxLength(6);

                entity.Property(e => e.RemAcc).HasMaxLength(35);

                entity.Property(e => e.RemAddr).HasMaxLength(144);

                entity.Property(e => e.RemBank)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.RemBankRefNo).HasMaxLength(20);

                entity.Property(e => e.RemCcy).HasMaxLength(3);

                entity.Property(e => e.RemDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RemStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RemType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RmForward).HasMaxLength(15);

                entity.Property(e => e.SWUuid).HasMaxLength(40);

                entity.Property(e => e.SenderAC).HasMaxLength(50);

                entity.Property(e => e.SenderInfo).HasMaxLength(500);

                entity.Property(e => e.SwiftFile).HasMaxLength(35);

                entity.Property(e => e.SwiftInfo).HasMaxLength(500);

                entity.Property(e => e.TaxRefund)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UID53).HasMaxLength(34);

                entity.Property(e => e.UID54).HasMaxLength(34);

                entity.Property(e => e.UID56).HasMaxLength(34);

                entity.Property(e => e.UID57).HasMaxLength(34);

                entity.Property(e => e.UID58).HasMaxLength(34);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.VoucherID).HasMaxLength(15);
            });

            modelBuilder.Entity<pRevalueRate>(entity =>
            {
                entity.HasKey(e => new { e.Reval_Date, e.Reval_Time, e.Reval_Ccy });

                entity.ToTable("pRevalueRate");

                entity.Property(e => e.Reval_Date).HasColumnType("smalldatetime");

                entity.Property(e => e.Reval_Time)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Reval_Ccy).HasMaxLength(3);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("datetime");

                entity.Property(e => e.Reval_Pack).HasDefaultValueSql("((0))");

                entity.Property(e => e.Reval_Rate).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pSBLC>(entity =>
            {
                entity.HasKey(e => new { e.SBLCNumber, e.RecType, e.SBLCSeqno });

                entity.ToTable("pSBLC");

                entity.Property(e => e.SBLCNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AOCode).HasMaxLength(5);

                entity.Property(e => e.Allocation).HasMaxLength(13);

                entity.Property(e => e.AmendFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AmendNo).HasMaxLength(20);

                entity.Property(e => e.AppvNo).HasMaxLength(15);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.BPOFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BankCode).HasMaxLength(20);

                entity.Property(e => e.BankDesc).HasMaxLength(2000);

                entity.Property(e => e.BankName).HasMaxLength(150);

                entity.Property(e => e.BenCode).HasMaxLength(6);

                entity.Property(e => e.BenInfo).HasMaxLength(144);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(20);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(20);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(20);

                entity.Property(e => e.CCS_LmType).HasMaxLength(3);

                entity.Property(e => e.Campaign_Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Campaign_EffDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.ChkExpiry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CommCollected)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CustAddr).HasMaxLength(144);

                entity.Property(e => e.CustCode).HasMaxLength(20);

                entity.Property(e => e.DMS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DateClaimBefore).HasColumnType("smalldatetime");

                entity.Property(e => e.DateExpiry).HasColumnType("smalldatetime");

                entity.Property(e => e.DateGenAcc).HasColumnType("smalldatetime");

                entity.Property(e => e.DateIssue).HasColumnType("smalldatetime");

                entity.Property(e => e.DateLastAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateLastPaid).HasColumnType("smalldatetime");

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateStartBond).HasColumnType("smalldatetime");

                entity.Property(e => e.DateToStop).HasColumnType("smalldatetime");

                entity.Property(e => e.DueStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Event)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventFlag)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.EventMode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FacNo).HasMaxLength(13);

                entity.Property(e => e.GenAccFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.InUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Informations).HasMaxLength(2000);

                entity.Property(e => e.IntFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntRateCode).HasMaxLength(10);

                entity.Property(e => e.IntStartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.InvoiceInfo).HasMaxLength(1000);

                entity.Property(e => e.LGMODE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LGTYPE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LOCode).HasMaxLength(8);

                entity.Property(e => e.LastIntDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LastReceiptNo).HasMaxLength(15);

                entity.Property(e => e.OverDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PastDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PayMethod).HasMaxLength(15);

                entity.Property(e => e.PayRemark).HasMaxLength(200);

                entity.Property(e => e.PaymentDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PrevBenCode).HasMaxLength(6);

                entity.Property(e => e.PrevBenInfo).HasMaxLength(144);

                entity.Property(e => e.PrevDateExpiry).HasColumnType("smalldatetime");

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SBLCCcy).HasMaxLength(3);

                entity.Property(e => e.SBLCRefNo).HasMaxLength(20);

                entity.Property(e => e.SBLCStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TRAppvNo).HasMaxLength(15);

                entity.Property(e => e.TaxRefund)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenorTerm).HasMaxLength(30);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.VoucherID).HasMaxLength(15);
            });

            modelBuilder.Entity<pSUMDMSPTX>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pSUMDMSPTX");

                entity.Property(e => e.AsAtDate).HasMaxLength(10);

                entity.Property(e => e.CntryIDOfInvolParty).HasMaxLength(2);

                entity.Property(e => e.CountryIdofIssuerorInvestedOrganization).HasMaxLength(2);

                entity.Property(e => e.CouponRate).HasMaxLength(20);

                entity.Property(e => e.CurrencyId).HasMaxLength(3);

                entity.Property(e => e.DebtInstrumentName).HasMaxLength(70);

                entity.Property(e => e.DebtInstrumentType).HasMaxLength(20);

                entity.Property(e => e.DefaultedBillPurchaseDate).HasMaxLength(8);

                entity.Property(e => e.EventType).HasMaxLength(25);

                entity.Property(e => e.ISINCode).HasMaxLength(10);

                entity.Property(e => e.IntentionCountryId).HasMaxLength(2);

                entity.Property(e => e.InvolPartyID).HasMaxLength(20);

                entity.Property(e => e.InvolPartyName).HasMaxLength(70);

                entity.Property(e => e.IssueDate).HasMaxLength(8);

                entity.Property(e => e.IssuerorInvestedOrganizationName).HasMaxLength(70);

                entity.Property(e => e.Keynumber).HasMaxLength(15);

                entity.Property(e => e.MaturityDate).HasMaxLength(8);

                entity.Property(e => e.NostroAcc).HasMaxLength(15);

                entity.Property(e => e.OriginalTerm).HasMaxLength(3);

                entity.Property(e => e.OriginalTermUnit).HasMaxLength(3);

                entity.Property(e => e.PaymentMethod).HasMaxLength(6);

                entity.Property(e => e.PeriodFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Product).HasMaxLength(4);

                entity.Property(e => e.RecpPayTrnCode).HasMaxLength(6);

                entity.Property(e => e.RecpPayTrnDate).HasMaxLength(10);

                entity.Property(e => e.RecpPayTrnItmDesc).HasMaxLength(50);

                entity.Property(e => e.RecpPayTrnItmType).HasMaxLength(6);

                entity.Property(e => e.RecpPayTrnType).HasMaxLength(6);

                entity.Property(e => e.RunDate).HasMaxLength(10);

                entity.Property(e => e.RunTime_U)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SellForeignCurSecTransAmtinBahtEqui).HasMaxLength(20);

                entity.Property(e => e.System).HasMaxLength(6);

                entity.Property(e => e.UnitofTransaction).HasMaxLength(5);
            });

            modelBuilder.Entity<pSW700>(entity =>
            {
                entity.HasKey(e => new { e.LCNo, e.LCSeq });

                entity.ToTable("pSW700");

                entity.Property(e => e.LCNo).HasMaxLength(15);

                entity.Property(e => e.F23).HasMaxLength(16);

                entity.Property(e => e.F25).HasMaxLength(35);

                entity.Property(e => e.F31C).HasMaxLength(6);

                entity.Property(e => e.F39A).HasMaxLength(5);

                entity.Property(e => e.F39B).HasMaxLength(13);

                entity.Property(e => e.F39C).HasMaxLength(148);

                entity.Property(e => e.F41Flag).HasMaxLength(3);

                entity.Property(e => e.F42A).HasMaxLength(181);

                entity.Property(e => e.F42C).HasMaxLength(108);

                entity.Property(e => e.F42D).HasMaxLength(148);

                entity.Property(e => e.F42M).HasMaxLength(650);

                entity.Property(e => e.F42M740).HasMaxLength(650);

                entity.Property(e => e.F42P).HasMaxLength(144);

                entity.Property(e => e.F43P).HasMaxLength(35);

                entity.Property(e => e.F43T).HasMaxLength(35);

                entity.Property(e => e.F44A).HasMaxLength(65);

                entity.Property(e => e.F44B).HasMaxLength(65);

                entity.Property(e => e.F44C).HasMaxLength(6);

                entity.Property(e => e.F44D).HasMaxLength(396);

                entity.Property(e => e.F44E).HasMaxLength(65);

                entity.Property(e => e.F44F).HasMaxLength(65);

                entity.Property(e => e.F45A)
                    .HasMaxLength(6600)
                    .IsUnicode(false);

                entity.Property(e => e.F48).HasMaxLength(144);

                entity.Property(e => e.F51).HasMaxLength(144);

                entity.Property(e => e.F53A).HasMaxLength(181);

                entity.Property(e => e.F57A).HasMaxLength(181);

                entity.Property(e => e.F57Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.F58A).HasMaxLength(14);

                entity.Property(e => e.F58D).HasMaxLength(148);

                entity.Property(e => e.F71A).HasMaxLength(3);

                entity.Property(e => e.F71A740).HasMaxLength(3);

                entity.Property(e => e.F71B).HasMaxLength(224);

                entity.Property(e => e.F71B740).HasMaxLength(224);

                entity.Property(e => e.F72).HasMaxLength(224);

                entity.Property(e => e.F72740).HasMaxLength(224);

                entity.Property(e => e.F78).HasMaxLength(792);

                entity.Property(e => e.Flag701)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.M20).HasMaxLength(16);

                entity.Property(e => e.M27).HasMaxLength(3);

                entity.Property(e => e.M27_1).HasMaxLength(3);

                entity.Property(e => e.M31D).HasMaxLength(35);

                entity.Property(e => e.M32B).HasMaxLength(18);

                entity.Property(e => e.M40A).HasMaxLength(50);

                entity.Property(e => e.M40E).HasMaxLength(35);

                entity.Property(e => e.M40F).HasMaxLength(30);

                entity.Property(e => e.M41).HasMaxLength(14);

                entity.Property(e => e.M41A).HasMaxLength(158);

                entity.Property(e => e.M49).HasMaxLength(7);

                entity.Property(e => e.M50).HasMaxLength(144);

                entity.Property(e => e.M59)
                    .IsRequired()
                    .HasMaxLength(180);

                entity.Property(e => e.SwiftFile).HasMaxLength(50);
            });

            modelBuilder.Entity<pSW700A>(entity =>
            {
                entity.HasKey(e => new { e.LCNo, e.SeqNo });

                entity.ToTable("pSW700A");

                entity.Property(e => e.LCNo).HasMaxLength(15);

                entity.Property(e => e.F45A)
                    .HasMaxLength(6600)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<pSW707>(entity =>
            {
                entity.HasKey(e => new { e.LCNo, e.Seqno });

                entity.ToTable("pSW707");

                entity.Property(e => e.LCNo).HasMaxLength(15);

                entity.Property(e => e.F26E).HasMaxLength(2);

                entity.Property(e => e.F30).HasMaxLength(6);

                entity.Property(e => e.F31C).HasMaxLength(6);

                entity.Property(e => e.F31E).HasMaxLength(6);

                entity.Property(e => e.F32B).HasMaxLength(18);

                entity.Property(e => e.F33B).HasMaxLength(18);

                entity.Property(e => e.F34B).HasMaxLength(18);

                entity.Property(e => e.F39A).HasMaxLength(5);

                entity.Property(e => e.F42A).HasMaxLength(181);

                entity.Property(e => e.F42C).HasMaxLength(108);

                entity.Property(e => e.F42M740).HasMaxLength(108);

                entity.Property(e => e.F42P).HasMaxLength(144);

                entity.Property(e => e.F44A).HasMaxLength(65);

                entity.Property(e => e.F44B).HasMaxLength(65);

                entity.Property(e => e.F44C).HasMaxLength(6);

                entity.Property(e => e.F44D).HasMaxLength(396);

                entity.Property(e => e.F71A740).HasMaxLength(3);

                entity.Property(e => e.F71B740).HasMaxLength(224);

                entity.Property(e => e.F72).HasMaxLength(224);

                entity.Property(e => e.F72740).HasMaxLength(224);

                entity.Property(e => e.F72747).HasMaxLength(224);

                entity.Property(e => e.F77A).HasMaxLength(738);

                entity.Property(e => e.F79).HasMaxLength(1818);

                entity.Property(e => e.FLAG740)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FLAG747)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.M20).HasMaxLength(16);

                entity.Property(e => e.M21).HasMaxLength(16);

                entity.Property(e => e.M30).HasMaxLength(6);

                entity.Property(e => e.M31D).HasMaxLength(35);

                entity.Property(e => e.M32B).HasMaxLength(18);

                entity.Property(e => e.M41A).HasMaxLength(158);

                entity.Property(e => e.M59).HasMaxLength(180);
            });

            modelBuilder.Entity<pSWExport>(entity =>
            {
                entity.HasKey(e => e.AutoNum);

                entity.ToTable("pSWExport");

                entity.Property(e => e.AutoNum).HasMaxLength(10);

                entity.Property(e => e.BankID).HasMaxLength(14);

                entity.Property(e => e.BankInFo).HasMaxLength(144);

                entity.Property(e => e.BankType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DocNo)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.Event).HasMaxLength(20);

                entity.Property(e => e.F20).HasMaxLength(16);

                entity.Property(e => e.F21).HasMaxLength(16);

                entity.Property(e => e.F23B).HasMaxLength(12);

                entity.Property(e => e.F25).HasMaxLength(35);

                entity.Property(e => e.F26T).HasMaxLength(19);

                entity.Property(e => e.F31).HasMaxLength(6);

                entity.Property(e => e.F32A).HasMaxLength(19);

                entity.Property(e => e.F32B).HasMaxLength(19);

                entity.Property(e => e.F33B).HasMaxLength(19);

                entity.Property(e => e.F34A).HasMaxLength(26);

                entity.Property(e => e.F34B).HasMaxLength(19);

                entity.Property(e => e.F52A).HasMaxLength(14);

                entity.Property(e => e.F52D).HasMaxLength(148);

                entity.Property(e => e.F52UID).HasMaxLength(35);

                entity.Property(e => e.F53A).HasMaxLength(12);

                entity.Property(e => e.F53D).HasMaxLength(148);

                entity.Property(e => e.F56A).HasMaxLength(14);

                entity.Property(e => e.F56D).HasMaxLength(148);

                entity.Property(e => e.F56UID).HasMaxLength(35);

                entity.Property(e => e.F57A).HasMaxLength(14);

                entity.Property(e => e.F57AC).HasMaxLength(15);

                entity.Property(e => e.F57D).HasMaxLength(148);

                entity.Property(e => e.F57UID).HasMaxLength(35);

                entity.Property(e => e.F58A).HasMaxLength(14);

                entity.Property(e => e.F58AC).HasMaxLength(15);

                entity.Property(e => e.F58D).HasMaxLength(148);

                entity.Property(e => e.F58UID).HasMaxLength(35);

                entity.Property(e => e.F59A).HasMaxLength(14);

                entity.Property(e => e.F59D).HasMaxLength(148);

                entity.Property(e => e.F59UID).HasMaxLength(35);

                entity.Property(e => e.F71B).HasMaxLength(216);

                entity.Property(e => e.F72).HasMaxLength(432);

                entity.Property(e => e.F73).HasMaxLength(216);

                entity.Property(e => e.F77).HasMaxLength(432);

                entity.Property(e => e.F77B).HasMaxLength(2100);

                entity.Property(e => e.F79).HasMaxLength(2100);

                entity.Property(e => e.MT499)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT730)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT742)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT768)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT799)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT999)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MTType).HasMaxLength(7);

                entity.Property(e => e.NBankID).HasMaxLength(14);

                entity.Property(e => e.NBankInfo).HasMaxLength(144);

                entity.Property(e => e.RemitCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SwiftFile).HasMaxLength(50);

                entity.Property(e => e.ValueDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pSWIMBC>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pSWIMBC");

                entity.Property(e => e.BCNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.F20).HasMaxLength(16);

                entity.Property(e => e.F21).HasMaxLength(25);

                entity.Property(e => e.F23).HasMaxLength(4);

                entity.Property(e => e.F26).HasMaxLength(3);

                entity.Property(e => e.F30).HasMaxLength(6);

                entity.Property(e => e.F32A).HasMaxLength(25);

                entity.Property(e => e.F32B).HasMaxLength(25);

                entity.Property(e => e.F33A).HasMaxLength(25);

                entity.Property(e => e.F50K).HasMaxLength(144);

                entity.Property(e => e.F52A).HasMaxLength(14);

                entity.Property(e => e.F52D).HasMaxLength(144);

                entity.Property(e => e.F53A).HasMaxLength(14);

                entity.Property(e => e.F53D).HasMaxLength(144);

                entity.Property(e => e.F56A).HasMaxLength(14);

                entity.Property(e => e.F56D).HasMaxLength(144);

                entity.Property(e => e.F56UID).HasMaxLength(20);

                entity.Property(e => e.F57A).HasMaxLength(14);

                entity.Property(e => e.F57D).HasMaxLength(144);

                entity.Property(e => e.F57UID).HasMaxLength(20);

                entity.Property(e => e.F58A).HasMaxLength(14);

                entity.Property(e => e.F58D).HasMaxLength(150);

                entity.Property(e => e.F58UID).HasMaxLength(20);

                entity.Property(e => e.F59A).HasMaxLength(35);

                entity.Property(e => e.F59D).HasMaxLength(144);

                entity.Property(e => e.F70).HasMaxLength(144);

                entity.Property(e => e.F71A).HasMaxLength(3);

                entity.Property(e => e.F71B).HasMaxLength(216);

                entity.Property(e => e.F72).HasMaxLength(432);

                entity.Property(e => e.F73).HasMaxLength(216);

                entity.Property(e => e.F77).HasMaxLength(432);

                entity.Property(e => e.F77B).HasMaxLength(720);

                entity.Property(e => e.F79).HasMaxLength(2100);

                entity.Property(e => e.MTType).HasMaxLength(7);

                entity.Property(e => e.ToWhom).HasMaxLength(220);
            });

            modelBuilder.Entity<pSWIMBL>(entity =>
            {
                entity.HasKey(e => new { e.ADNumber, e.Seqno });

                entity.ToTable("pSWIMBL");

                entity.Property(e => e.ADNumber).HasMaxLength(15);

                entity.Property(e => e.BLNumber).HasMaxLength(15);

                entity.Property(e => e.F20).HasMaxLength(16);

                entity.Property(e => e.F21).HasMaxLength(16);

                entity.Property(e => e.F23).HasMaxLength(16);

                entity.Property(e => e.F30).HasMaxLength(6);

                entity.Property(e => e.F32A).HasMaxLength(29);

                entity.Property(e => e.F32B).HasMaxLength(25);

                entity.Property(e => e.F33A).HasMaxLength(25);

                entity.Property(e => e.F52A).HasMaxLength(14);

                entity.Property(e => e.F52D).HasMaxLength(144);

                entity.Property(e => e.F53A).HasMaxLength(14);

                entity.Property(e => e.F53D).HasMaxLength(144);

                entity.Property(e => e.F56A).HasMaxLength(14);

                entity.Property(e => e.F56D).HasMaxLength(144);

                entity.Property(e => e.F56UID).HasMaxLength(20);

                entity.Property(e => e.F57A).HasMaxLength(14);

                entity.Property(e => e.F57D).HasMaxLength(144);

                entity.Property(e => e.F57UID).HasMaxLength(20);

                entity.Property(e => e.F58A).HasMaxLength(14);

                entity.Property(e => e.F58D).HasMaxLength(144);

                entity.Property(e => e.F58UID).HasMaxLength(20);

                entity.Property(e => e.F71B).HasMaxLength(2100);

                entity.Property(e => e.F72).HasMaxLength(432);

                entity.Property(e => e.F73).HasMaxLength(220);

                entity.Property(e => e.F77).HasMaxLength(432);

                entity.Property(e => e.F77B).HasMaxLength(720);

                entity.Property(e => e.F79).HasMaxLength(2100);

                entity.Property(e => e.MTType).HasMaxLength(7);

                entity.Property(e => e.ToWhom).HasMaxLength(144);
            });

            modelBuilder.Entity<pSWIMLC>(entity =>
            {
                entity.HasKey(e => new { e.LCNo, e.LCSeq });

                entity.ToTable("pSWIMLC");

                entity.Property(e => e.LCNo).HasMaxLength(15);

                entity.Property(e => e.F20).HasMaxLength(16);

                entity.Property(e => e.F21).HasMaxLength(16);

                entity.Property(e => e.F21C).HasMaxLength(16);

                entity.Property(e => e.F21_X).HasMaxLength(16);

                entity.Property(e => e.F22R).HasMaxLength(10);

                entity.Property(e => e.F23).HasMaxLength(16);

                entity.Property(e => e.F23S).HasMaxLength(10);

                entity.Property(e => e.F25).HasMaxLength(35);

                entity.Property(e => e.F26E).HasMaxLength(3);

                entity.Property(e => e.F27).HasMaxLength(5);

                entity.Property(e => e.F27_X).HasMaxLength(5);

                entity.Property(e => e.F30).HasMaxLength(6);

                entity.Property(e => e.F31C).HasMaxLength(6);

                entity.Property(e => e.F31D).HasMaxLength(35);

                entity.Property(e => e.F31DX).HasMaxLength(35);

                entity.Property(e => e.F31E).HasMaxLength(6);

                entity.Property(e => e.F32B).HasMaxLength(18);

                entity.Property(e => e.F33B).HasMaxLength(18);

                entity.Property(e => e.F34B).HasMaxLength(18);

                entity.Property(e => e.F39A).HasMaxLength(5);

                entity.Property(e => e.F39B).HasMaxLength(13);

                entity.Property(e => e.F39C).HasMaxLength(148);

                entity.Property(e => e.F40A).HasMaxLength(24);

                entity.Property(e => e.F40E).HasMaxLength(1050);

                entity.Property(e => e.F40F).HasMaxLength(30);

                entity.Property(e => e.F41A).HasMaxLength(14);

                entity.Property(e => e.F41D).HasMaxLength(148);

                entity.Property(e => e.F41Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.F41UID).HasMaxLength(35);

                entity.Property(e => e.F42A).HasMaxLength(14);

                entity.Property(e => e.F42C).HasMaxLength(108);

                entity.Property(e => e.F42D).HasMaxLength(148);

                entity.Property(e => e.F42M).HasMaxLength(148);

                entity.Property(e => e.F42P).HasMaxLength(148);

                entity.Property(e => e.F42UID).HasMaxLength(35);

                entity.Property(e => e.F43P).HasMaxLength(35);

                entity.Property(e => e.F43T).HasMaxLength(35);

                entity.Property(e => e.F44A).HasMaxLength(65);

                entity.Property(e => e.F44B).HasMaxLength(65);

                entity.Property(e => e.F44C).HasMaxLength(6);

                entity.Property(e => e.F44D).HasMaxLength(400);

                entity.Property(e => e.F44E).HasMaxLength(65);

                entity.Property(e => e.F44F).HasMaxLength(65);

                entity.Property(e => e.F48).HasMaxLength(148);

                entity.Property(e => e.F49).HasMaxLength(10);

                entity.Property(e => e.F50).HasMaxLength(148);

                entity.Property(e => e.F50DX).HasMaxLength(148);

                entity.Property(e => e.F51A).HasMaxLength(14);

                entity.Property(e => e.F51D).HasMaxLength(148);

                entity.Property(e => e.F51UID).HasMaxLength(35);

                entity.Property(e => e.F53A).HasMaxLength(14);

                entity.Property(e => e.F53D).HasMaxLength(148);

                entity.Property(e => e.F53UID).HasMaxLength(35);

                entity.Property(e => e.F57A).HasMaxLength(14);

                entity.Property(e => e.F57A1).HasMaxLength(14);

                entity.Property(e => e.F57D).HasMaxLength(148);

                entity.Property(e => e.F57D1).HasMaxLength(148);

                entity.Property(e => e.F57UID).HasMaxLength(35);

                entity.Property(e => e.F57UID1).HasMaxLength(35);

                entity.Property(e => e.F58A).HasMaxLength(14);

                entity.Property(e => e.F58A1).HasMaxLength(14);

                entity.Property(e => e.F58D).HasMaxLength(148);

                entity.Property(e => e.F58D1).HasMaxLength(148);

                entity.Property(e => e.F58UID).HasMaxLength(35);

                entity.Property(e => e.F58UID1).HasMaxLength(35);

                entity.Property(e => e.F59).HasMaxLength(148);

                entity.Property(e => e.F59DX).HasMaxLength(148);

                entity.Property(e => e.F59UID).HasMaxLength(35);

                entity.Property(e => e.F59UIDX).HasMaxLength(35);

                entity.Property(e => e.F71A).HasMaxLength(3);

                entity.Property(e => e.F71B).HasMaxLength(220);

                entity.Property(e => e.F71B_X).HasMaxLength(220);

                entity.Property(e => e.F72).HasMaxLength(220);

                entity.Property(e => e.F72_X).HasMaxLength(220);

                entity.Property(e => e.F77A).HasMaxLength(740);

                entity.Property(e => e.F78).HasMaxLength(800);

                entity.Property(e => e.F79).HasMaxLength(1700);

                entity.Property(e => e.F79C).HasMaxLength(1700);

                entity.Property(e => e.Flag701)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Flag740)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Flag747)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LCCcy).HasMaxLength(3);

                entity.Property(e => e.LCEvent).HasMaxLength(15);

                entity.Property(e => e.SwiftFile).HasMaxLength(50);

                entity.Property(e => e.ToBank).HasMaxLength(14);

                entity.Property(e => e.ToReim).HasMaxLength(14);

                entity.Property(e => e.ValueDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pSWIMTR>(entity =>
            {
                entity.HasKey(e => new { e.RefNumber, e.Seqno });

                entity.ToTable("pSWIMTR");

                entity.Property(e => e.RefNumber).HasMaxLength(15);

                entity.Property(e => e.F20).HasMaxLength(16);

                entity.Property(e => e.F21).HasMaxLength(16);

                entity.Property(e => e.F23).HasMaxLength(4);

                entity.Property(e => e.F26).HasMaxLength(3);

                entity.Property(e => e.F32A).HasMaxLength(25);

                entity.Property(e => e.F50K).HasMaxLength(144);

                entity.Property(e => e.F56A).HasMaxLength(12);

                entity.Property(e => e.F56D).HasMaxLength(144);

                entity.Property(e => e.F56UID).HasMaxLength(12);

                entity.Property(e => e.F57A).HasMaxLength(12);

                entity.Property(e => e.F57D).HasMaxLength(144);

                entity.Property(e => e.F57UID).HasMaxLength(12);

                entity.Property(e => e.F58A).HasMaxLength(12);

                entity.Property(e => e.F58D).HasMaxLength(144);

                entity.Property(e => e.F58UID).HasMaxLength(12);

                entity.Property(e => e.F59A).HasMaxLength(35);

                entity.Property(e => e.F59D).HasMaxLength(144);

                entity.Property(e => e.F71A).HasMaxLength(3);

                entity.Property(e => e.F72).HasMaxLength(432);

                entity.Property(e => e.F79).HasMaxLength(2100);

                entity.Property(e => e.MTType).HasMaxLength(7);

                entity.Property(e => e.TRNumber).HasMaxLength(15);

                entity.Property(e => e.ToWhom).HasMaxLength(144);
            });

            modelBuilder.Entity<pSWImpSBLC>(entity =>
            {
                entity.HasKey(e => new { e.DocNumber, e.SeqNo, e.MTNo });

                entity.ToTable("pSWImpSBLC");

                entity.Property(e => e.DocNumber).HasMaxLength(15);

                entity.Property(e => e.MTNo).HasMaxLength(3);

                entity.Property(e => e.F22K_C).HasMaxLength(4);

                entity.Property(e => e.F22K_D).HasMaxLength(35);

                entity.Property(e => e.F22Y).HasMaxLength(4);

                entity.Property(e => e.F23).HasMaxLength(16);

                entity.Property(e => e.F23E).HasMaxLength(40);

                entity.Property(e => e.F23E_C).HasMaxLength(4);

                entity.Property(e => e.F23F_C).HasMaxLength(4);

                entity.Property(e => e.F23F_D).HasMaxLength(35);

                entity.Property(e => e.F23X_C).HasMaxLength(4);

                entity.Property(e => e.F23X_D).HasMaxLength(65);

                entity.Property(e => e.F24E_C).HasMaxLength(4);

                entity.Property(e => e.F24E_D).HasMaxLength(35);

                entity.Property(e => e.F24G_C).HasMaxLength(4);

                entity.Property(e => e.F24G_D).HasMaxLength(216);

                entity.Property(e => e.F26E).HasMaxLength(3);

                entity.Property(e => e.F31E).HasMaxLength(6);

                entity.Property(e => e.F31S).HasMaxLength(6);

                entity.Property(e => e.F35G).HasMaxLength(792);

                entity.Property(e => e.F39D).HasMaxLength(792);

                entity.Property(e => e.F39E).HasMaxLength(792);

                entity.Property(e => e.F40D).HasMaxLength(2);

                entity.Property(e => e.F41A).HasMaxLength(14);

                entity.Property(e => e.F41D).HasMaxLength(148);

                entity.Property(e => e.F41UID).HasMaxLength(35);

                entity.Property(e => e.F44H).HasMaxLength(68);

                entity.Property(e => e.F44H_C).HasMaxLength(30);

                entity.Property(e => e.F45L).HasMaxLength(3300);

                entity.Property(e => e.F48B).HasMaxLength(4);

                entity.Property(e => e.F48D).HasMaxLength(4);

                entity.Property(e => e.F49).HasMaxLength(7);

                entity.Property(e => e.F50).HasMaxLength(144);

                entity.Property(e => e.F51).HasMaxLength(144);

                entity.Property(e => e.F56A).HasMaxLength(13);

                entity.Property(e => e.F56D).HasMaxLength(148);

                entity.Property(e => e.F56UID).HasMaxLength(35);

                entity.Property(e => e.F57A).HasMaxLength(13);

                entity.Property(e => e.F57D).HasMaxLength(148);

                entity.Property(e => e.F57UID).HasMaxLength(35);

                entity.Property(e => e.F58A).HasMaxLength(13);

                entity.Property(e => e.F58D).HasMaxLength(148);

                entity.Property(e => e.F58UID).HasMaxLength(35);

                entity.Property(e => e.F71D).HasMaxLength(216);

                entity.Property(e => e.F72).HasMaxLength(216);

                entity.Property(e => e.F78).HasMaxLength(792);

                entity.Property(e => e.M22A).HasMaxLength(4);

                entity.Property(e => e.M22D).HasMaxLength(4);

                entity.Property(e => e.M23B).HasMaxLength(4);

                entity.Property(e => e.M27).HasMaxLength(3);

                entity.Property(e => e.M27_X).HasMaxLength(3);

                entity.Property(e => e.M30).HasMaxLength(6);

                entity.Property(e => e.M32B).HasMaxLength(18);

                entity.Property(e => e.M40C_C).HasMaxLength(4);

                entity.Property(e => e.M40C_D).HasMaxLength(35);

                entity.Property(e => e.M52A).HasMaxLength(13);

                entity.Property(e => e.M52D).HasMaxLength(148);

                entity.Property(e => e.M52UID).HasMaxLength(35);

                entity.Property(e => e.M59A).HasMaxLength(13);

                entity.Property(e => e.M59D).HasMaxLength(148);

                entity.Property(e => e.M59Uid).HasMaxLength(35);

                entity.Property(e => e.SwiftFile).HasMaxLength(20);
            });

            modelBuilder.Entity<pSWImpText>(entity =>
            {
                entity.HasKey(e => new { e.Login, e.DocNumber, e.Seqno, e.MTNo, e.FDNo });

                entity.ToTable("pSWImpText");

                entity.Property(e => e.Login).HasMaxLength(5);

                entity.Property(e => e.DocNumber).HasMaxLength(15);

                entity.Property(e => e.MTNo).HasMaxLength(5);

                entity.Property(e => e.FDNo)
                    .HasMaxLength(15)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<pSWImport>(entity =>
            {
                entity.HasKey(e => new { e.Login, e.DocNumber, e.Seqno });

                entity.ToTable("pSWImport");

                entity.Property(e => e.Login).HasMaxLength(5);

                entity.Property(e => e.DocNumber).HasMaxLength(15);

                entity.Property(e => e.BNet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CF50)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CF59)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Detail32).HasMaxLength(15);

                entity.Property(e => e.F20).HasMaxLength(16);

                entity.Property(e => e.F20_X).HasMaxLength(16);

                entity.Property(e => e.F21).HasMaxLength(16);

                entity.Property(e => e.F21_B).HasMaxLength(16);

                entity.Property(e => e.F21_C).HasMaxLength(16);

                entity.Property(e => e.F21_X).HasMaxLength(16);

                entity.Property(e => e.F23).HasMaxLength(4);

                entity.Property(e => e.F23_X).HasMaxLength(15);

                entity.Property(e => e.F26).HasMaxLength(3);

                entity.Property(e => e.F30).HasMaxLength(6);

                entity.Property(e => e.F32A).HasMaxLength(25);

                entity.Property(e => e.F32B).HasMaxLength(25);

                entity.Property(e => e.F33A).HasMaxLength(25);

                entity.Property(e => e.F33B).HasMaxLength(25);

                entity.Property(e => e.F34A).HasMaxLength(25);

                entity.Property(e => e.F50K).HasMaxLength(185);

                entity.Property(e => e.F52A).HasMaxLength(13);

                entity.Property(e => e.F52D).HasMaxLength(148);

                entity.Property(e => e.F53A).HasMaxLength(13);

                entity.Property(e => e.F53A_X).HasMaxLength(13);

                entity.Property(e => e.F53B).HasMaxLength(35);

                entity.Property(e => e.F53B_X).HasMaxLength(35);

                entity.Property(e => e.F53D).HasMaxLength(148);

                entity.Property(e => e.F53D_X).HasMaxLength(148);

                entity.Property(e => e.F53UID).HasMaxLength(35);

                entity.Property(e => e.F53UID_X).HasMaxLength(35);

                entity.Property(e => e.F54A).HasMaxLength(13);

                entity.Property(e => e.F54A_X).HasMaxLength(13);

                entity.Property(e => e.F54D).HasMaxLength(148);

                entity.Property(e => e.F54D_X).HasMaxLength(148);

                entity.Property(e => e.F54UID).HasMaxLength(35);

                entity.Property(e => e.F54UID_X).HasMaxLength(35);

                entity.Property(e => e.F56A).HasMaxLength(13);

                entity.Property(e => e.F56D).HasMaxLength(148);

                entity.Property(e => e.F56UID).HasMaxLength(35);

                entity.Property(e => e.F57A).HasMaxLength(13);

                entity.Property(e => e.F57D).HasMaxLength(148);

                entity.Property(e => e.F57UID).HasMaxLength(35);

                entity.Property(e => e.F58A).HasMaxLength(13);

                entity.Property(e => e.F58D).HasMaxLength(148);

                entity.Property(e => e.F58UID).HasMaxLength(35);

                entity.Property(e => e.F59).HasMaxLength(185);

                entity.Property(e => e.F70).HasMaxLength(148);

                entity.Property(e => e.F71A).HasMaxLength(3);

                entity.Property(e => e.F71B).HasMaxLength(216);

                entity.Property(e => e.F71F).HasMaxLength(25);

                entity.Property(e => e.F72).HasMaxLength(216);

                entity.Property(e => e.F72103).HasMaxLength(216);

                entity.Property(e => e.F72_X).HasMaxLength(216);

                entity.Property(e => e.F73).HasMaxLength(216);

                entity.Property(e => e.F77A).HasMaxLength(720);

                entity.Property(e => e.F77B).HasMaxLength(108);

                entity.Property(e => e.F77J).HasMaxLength(3750);

                entity.Property(e => e.F79).HasMaxLength(1820);

                entity.Property(e => e.F79_X).HasMaxLength(1820);

                entity.Property(e => e.F79_Z).HasMaxLength(1820);

                entity.Property(e => e.Flag32)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT103)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT199)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT202)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT202Cov)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT400)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT412)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT499)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT734)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT752)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT754)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT756)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT799)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MT999)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RefNumber).HasMaxLength(15);

                entity.Property(e => e.RemitCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SWUuid).HasMaxLength(40);

                entity.Property(e => e.SwiftFile).HasMaxLength(50);

                entity.Property(e => e.ToBank).HasMaxLength(13);

                entity.Property(e => e.ToName).HasMaxLength(148);

                entity.Property(e => e.ToNego).HasMaxLength(13);

                entity.Property(e => e.ToRefer).HasMaxLength(35);

                entity.Property(e => e.ToWhom).HasMaxLength(148);

                entity.Property(e => e.ValueDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<pSWMisc>(entity =>
            {
                entity.HasKey(e => new { e.Login, e.RefNumber, e.Seqno });

                entity.ToTable("pSWMisc");

                entity.Property(e => e.Login).HasMaxLength(4);

                entity.Property(e => e.RefNumber).HasMaxLength(15);

                entity.Property(e => e.DOCNumber).HasMaxLength(15);

                entity.Property(e => e.F20).HasMaxLength(16);

                entity.Property(e => e.F21).HasMaxLength(16);

                entity.Property(e => e.F32A).HasMaxLength(25);

                entity.Property(e => e.F52A).HasMaxLength(14);

                entity.Property(e => e.F52D).HasMaxLength(150);

                entity.Property(e => e.F53A).HasMaxLength(14);

                entity.Property(e => e.F53D).HasMaxLength(150);

                entity.Property(e => e.F53UID).HasMaxLength(35);

                entity.Property(e => e.F54A).HasMaxLength(14);

                entity.Property(e => e.F54D).HasMaxLength(150);

                entity.Property(e => e.F54UID).HasMaxLength(35);

                entity.Property(e => e.F56A).HasMaxLength(14);

                entity.Property(e => e.F56D).HasMaxLength(150);

                entity.Property(e => e.F56UID).HasMaxLength(35);

                entity.Property(e => e.F57A).HasMaxLength(14);

                entity.Property(e => e.F57D).HasMaxLength(150);

                entity.Property(e => e.F57UID).HasMaxLength(35);

                entity.Property(e => e.F58A).HasMaxLength(12);

                entity.Property(e => e.F58D).HasMaxLength(150);

                entity.Property(e => e.F58UID).HasMaxLength(35);

                entity.Property(e => e.F72).HasMaxLength(432);

                entity.Property(e => e.F79).HasMaxLength(2100);

                entity.Property(e => e.MTType).HasMaxLength(7);

                entity.Property(e => e.ToWhom).HasMaxLength(150);
            });

            modelBuilder.Entity<pSWPrint>(entity =>
            {
                entity.HasKey(e => new { e.SWFileName, e.SWUser, e.SwSeq });

                entity.ToTable("pSWPrint");

                entity.Property(e => e.SWFileName).HasMaxLength(70);

                entity.Property(e => e.SWUser).HasMaxLength(12);

                entity.Property(e => e.SwDesc)
                    .HasMaxLength(6600)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<pSWPrintFM>(entity =>
            {
                entity.HasKey(e => new { e.SWFileName, e.SWUser, e.SwSeq })
                    .HasName("PK_pSWPintFM");

                entity.ToTable("pSWPrintFM");

                entity.Property(e => e.SWFileName).HasMaxLength(70);

                entity.Property(e => e.SWUser).HasMaxLength(12);

                entity.Property(e => e.SwDesc)
                    .HasMaxLength(6600)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<pSWSending>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pSWSending");

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DocDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DocNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Event).HasMaxLength(25);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventFlag)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RefNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<pSWTextLoad>(entity =>
            {
                entity.HasKey(e => new { e.LCSwName, e.LCNo, e.LCLine });

                entity.ToTable("pSWTextLoad");

                entity.Property(e => e.LCSwName).HasMaxLength(20);

                entity.Property(e => e.LCNo).HasMaxLength(15);

                entity.Property(e => e.ACCESS_ID)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Edition_Number)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.LCData).HasMaxLength(200);

                entity.Property(e => e.MsgNo).HasMaxLength(3);

                entity.Property(e => e.Trade_ref_Number)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<pSendLCMail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pSendLCMail");

                entity.Property(e => e.ACCESS_ID)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.LC_Number).HasMaxLength(15);

                entity.Property(e => e.SendDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<pSumDMSFLA>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pSumDMSFLA");

                entity.Property(e => e.ACCDCounterpartyType).HasMaxLength(50);

                entity.Property(e => e.ACCDLicenseScheme).HasMaxLength(50);

                entity.Property(e => e.ArrangeContDate).HasMaxLength(8);

                entity.Property(e => e.ArrangeTerm).HasMaxLength(3);

                entity.Property(e => e.ArrangeTermType).HasMaxLength(6);

                entity.Property(e => e.ArrangeTermUnit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AsAtDate).HasMaxLength(10);

                entity.Property(e => e.CallOpWholeFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CentralID).HasMaxLength(9);

                entity.Property(e => e.ContractCcyID).HasMaxLength(3);

                entity.Property(e => e.CreditType).HasMaxLength(8);

                entity.Property(e => e.DataProviderBranchNumber).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.EffectiveDate).HasMaxLength(8);

                entity.Property(e => e.EventType).HasMaxLength(25);

                entity.Property(e => e.ExtendedFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FIArrangementNo).HasMaxLength(15);

                entity.Property(e => e.FirstDisburseDate).HasMaxLength(8);

                entity.Property(e => e.FirstRepaymentDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntRateType).HasMaxLength(10);

                entity.Property(e => e.IntRepayTerm).HasMaxLength(3);

                entity.Property(e => e.IntRepayTermUnit).HasMaxLength(1);

                entity.Property(e => e.Keynumber).HasMaxLength(15);

                entity.Property(e => e.LoanCallOptExAmt).HasMaxLength(8);

                entity.Property(e => e.LoanCallOptExDate).HasMaxLength(8);

                entity.Property(e => e.LoanPutOptExDate).HasMaxLength(8);

                entity.Property(e => e.LoanType).HasMaxLength(6);

                entity.Property(e => e.MaturityDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PeriodFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PrevArrangeNum).HasMaxLength(6);

                entity.Property(e => e.PrimaryInvoBrnNum).HasMaxLength(6);

                entity.Property(e => e.PrimaryInvoIBF).HasMaxLength(6);

                entity.Property(e => e.PrnRepayTermUnit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Product).HasMaxLength(4);

                entity.Property(e => e.PutOpWholeFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RelInvoPartyName).HasMaxLength(50);

                entity.Property(e => e.RunDate).HasMaxLength(10);

                entity.Property(e => e.RunTime)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.System).HasMaxLength(6);

                entity.Property(e => e.TXSeq).HasMaxLength(4);
            });

            modelBuilder.Entity<pSumDMSFTU>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pSumDMSFTU");

                entity.Property(e => e.AsAtDate).HasMaxLength(10);

                entity.Property(e => e.BenCnty).HasMaxLength(2);

                entity.Property(e => e.CurID).HasMaxLength(3);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.EventType).HasMaxLength(25);

                entity.Property(e => e.ExcInvPartyBusType).HasMaxLength(7);

                entity.Property(e => e.FXArrangeType).HasMaxLength(6);

                entity.Property(e => e.InFlowTXPurpose).HasMaxLength(6);

                entity.Property(e => e.Keynumber).HasMaxLength(15);

                entity.Property(e => e.LegType).HasMaxLength(6);

                entity.Property(e => e.OutFlowTXPurpose).HasMaxLength(6);

                entity.Property(e => e.PeriodFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Product).HasMaxLength(4);

                entity.Property(e => e.RunDate).HasMaxLength(10);

                entity.Property(e => e.RunTime_U)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.System).HasMaxLength(6);

                entity.Property(e => e.TXSeq).HasMaxLength(4);
            });

            modelBuilder.Entity<pSumDMSFTX>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pSumDMSFTX");

                entity.Property(e => e.ACCDCounterpartyType).HasMaxLength(200);

                entity.Property(e => e.ACCDLicenseScheme).HasMaxLength(200);

                entity.Property(e => e.AppvDocDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AppvDocNo).HasMaxLength(15);

                entity.Property(e => e.AsAtDate).HasMaxLength(10);

                entity.Property(e => e.BenCnty).HasMaxLength(2);

                entity.Property(e => e.BenName).HasMaxLength(200);

                entity.Property(e => e.BotReferenceNumber).HasMaxLength(50);

                entity.Property(e => e.BuyCurID).HasMaxLength(3);

                entity.Property(e => e.CancelationReasonType).HasMaxLength(50);

                entity.Property(e => e.CancellationReasonType).HasMaxLength(200);

                entity.Property(e => e.CentralID).HasMaxLength(50);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.CustInvestType)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DebtInstruIssueDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.EventType).HasMaxLength(25);

                entity.Property(e => e.ExcInvPartyBrNo).HasMaxLength(4);

                entity.Property(e => e.ExcInvPartyBusType).HasMaxLength(7);

                entity.Property(e => e.ExcInvPartyIBFInd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ExcInvPartyName).HasMaxLength(70);

                entity.Property(e => e.FIArrangementNo).HasMaxLength(15);

                entity.Property(e => e.FXArrangeType).HasMaxLength(6);

                entity.Property(e => e.FXTradingTXType).HasMaxLength(6);

                entity.Property(e => e.FirstDisburDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FirstInstallDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FromTXType).HasMaxLength(6);

                entity.Property(e => e.FromToAccNo).HasMaxLength(19);

                entity.Property(e => e.FromToFICode).HasMaxLength(6);

                entity.Property(e => e.FromToRelTXDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.InFlowTXPurpose).HasMaxLength(6);

                entity.Property(e => e.InstallTermUnit)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IntRateType).HasMaxLength(10);

                entity.Property(e => e.InvestReason).HasMaxLength(200);

                entity.Property(e => e.KeyInTimestamp).HasMaxLength(200);

                entity.Property(e => e.Keynumber).HasMaxLength(15);

                entity.Property(e => e.ListinMarketFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LoanDecType)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MaturityDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NoofInstall)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NoofShare).HasMaxLength(3);

                entity.Property(e => e.NotionalCurID).HasMaxLength(3);

                entity.Property(e => e.ObjectiveType).HasMaxLength(50);

                entity.Property(e => e.OthTXPurposeDesc).HasMaxLength(200);

                entity.Property(e => e.OutFlowTXPurpose).HasMaxLength(6);

                entity.Property(e => e.OutsNotCurID).HasMaxLength(3);

                entity.Property(e => e.ParValue).HasMaxLength(3);

                entity.Property(e => e.PaymentMeth).HasMaxLength(6);

                entity.Property(e => e.PeriodFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PreviousArrangementFICode).HasMaxLength(200);

                entity.Property(e => e.PreviousArrangementNumber).HasMaxLength(200);

                entity.Property(e => e.Product).HasMaxLength(4);

                entity.Property(e => e.RePayDueIndicator)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RelInvPartyBusType).HasMaxLength(7);

                entity.Property(e => e.RelInvPartyName).HasMaxLength(70);

                entity.Property(e => e.RelationRelInvParty).HasMaxLength(6);

                entity.Property(e => e.RelationwithBen).HasMaxLength(6);

                entity.Property(e => e.RunDate).HasMaxLength(10);

                entity.Property(e => e.RunTime)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SellCurID).HasMaxLength(3);

                entity.Property(e => e.SetUpReasonType).HasMaxLength(200);

                entity.Property(e => e.System).HasMaxLength(6);

                entity.Property(e => e.TXDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TXPurposeCode).HasMaxLength(6);

                entity.Property(e => e.TXSeq).HasMaxLength(4);

                entity.Property(e => e.TermRange)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ToTXType).HasMaxLength(6);

                entity.Property(e => e.UnderlyingOwnerName).HasMaxLength(50);

                entity.Property(e => e.WholePartRepayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<pSumDMSLTX>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pSumDMSLTX");

                entity.Property(e => e.AppvDocDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AppvDocNo).HasMaxLength(15);

                entity.Property(e => e.AsAtDate).HasMaxLength(10);

                entity.Property(e => e.BenCnty).HasMaxLength(20);

                entity.Property(e => e.BenName).HasMaxLength(200);

                entity.Property(e => e.BotReferenceNumber).HasMaxLength(200);

                entity.Property(e => e.CurrencyID).HasMaxLength(3);

                entity.Property(e => e.CustInvestType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DataProviderBranchNumber).HasMaxLength(200);

                entity.Property(e => e.DebtInstruIssueDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.EventType).HasMaxLength(25);

                entity.Property(e => e.FIArrangementNo).HasMaxLength(15);

                entity.Property(e => e.FirstDisburDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FirstInstallDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FromTXType).HasMaxLength(6);

                entity.Property(e => e.FromToAccNo).HasMaxLength(19);

                entity.Property(e => e.FromToFICode).HasMaxLength(6);

                entity.Property(e => e.FromToRelTXDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.InFlowTXPurpose).HasMaxLength(6);

                entity.Property(e => e.InstallTermUnit)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.InstallmentNo).HasMaxLength(2);

                entity.Property(e => e.IntRateType).HasMaxLength(10);

                entity.Property(e => e.InvestReason).HasMaxLength(200);

                entity.Property(e => e.Keynumber).HasMaxLength(15);

                entity.Property(e => e.ListinMarketFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LoanDecType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LoanDepositTrxType).HasMaxLength(6);

                entity.Property(e => e.MaturityDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NoOfShare).HasMaxLength(3);

                entity.Property(e => e.NoofInstall)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.OthRepayResonDesc).HasMaxLength(50);

                entity.Property(e => e.OthTXPurposeDesc).HasMaxLength(200);

                entity.Property(e => e.OutFlowTXPurpose).HasMaxLength(6);

                entity.Property(e => e.ParValue).HasMaxLength(3);

                entity.Property(e => e.PaymentMeth).HasMaxLength(6);

                entity.Property(e => e.PeriodFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Product).HasMaxLength(4);

                entity.Property(e => e.RePayDueIndicator)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RelationwithBen).HasMaxLength(6);

                entity.Property(e => e.RepaymentReson).HasMaxLength(6);

                entity.Property(e => e.ResCentralID).HasMaxLength(8);

                entity.Property(e => e.RunDate).HasMaxLength(10);

                entity.Property(e => e.RunTime)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.System).HasMaxLength(6);

                entity.Property(e => e.TXPurposeCode).HasMaxLength(6);

                entity.Property(e => e.TXSeq).HasMaxLength(4);

                entity.Property(e => e.TermRange)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ToTXType).HasMaxLength(6);

                entity.Property(e => e.TransactionDate).HasMaxLength(8);

                entity.Property(e => e.UnderlyingOwnerName).HasMaxLength(200);

                entity.Property(e => e.WholePartRepayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<pTradeApp>(entity =>
            {
                entity.HasKey(e => new { e.Company_ID, e.Trade_ref_Number, e.Edition_Number });

                entity.ToTable("pTradeApp");

                entity.Property(e => e.Trade_ref_Number)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Edition_Number)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.LC_Number).HasMaxLength(13);
            });

            modelBuilder.Entity<pTranFcdBalance>(entity =>
            {
                entity.HasKey(e => new { e.FcdAccNo, e.TranDoc });

                entity.ToTable("pTranFcdBalance");

                entity.Property(e => e.FcdAccNo).HasMaxLength(13);

                entity.Property(e => e.TranDoc).HasMaxLength(15);

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.AuthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.DateLastAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DateToStop).HasColumnType("smalldatetime");

                entity.Property(e => e.DepositDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FcdCcy).HasMaxLength(3);

                entity.Property(e => e.FcdCross)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FcdSavFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FlagRate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.HoldFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.TranFFlag).HasMaxLength(5);

                entity.Property(e => e.TranFStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TranFType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<pTransfer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pTransfer");

                entity.Property(e => e.ALLOCATION)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AUTH_CODE).HasMaxLength(10);

                entity.Property(e => e.AUTH_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.BUSINESS_TYPE)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.EVENT_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.EVENT_TYPE).HasMaxLength(25);

                entity.Property(e => e.EXPORT_ADVICE_NO)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.GENACC_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.GENACC_FLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IN_Use)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LC_Currency).HasMaxLength(3);

                entity.Property(e => e.LC_NO).HasMaxLength(35);

                entity.Property(e => e.METHOD).HasMaxLength(10);

                entity.Property(e => e.PAYMENT_INSTRU)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PAY_REFUND)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PREV_EXPIRY).HasColumnType("smalldatetime");

                entity.Property(e => e.REASON_OF_CANCEL).HasMaxLength(140);

                entity.Property(e => e.RECEIPT_NO).HasMaxLength(15);

                entity.Property(e => e.RECORD_TYPE).HasMaxLength(10);

                entity.Property(e => e.REC_STATUS).HasMaxLength(10);

                entity.Property(e => e.REMARK).HasMaxLength(140);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SUBSTATION_DOC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TRANSFER_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.TRANSFER_EXPIRY_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.TRANSFER_ID).HasMaxLength(13);

                entity.Property(e => e.TRANSFER_INFO).HasMaxLength(180);

                entity.Property(e => e.TRANSFER_OTHER)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TRANSFER_TYPE).HasMaxLength(3);

                entity.Property(e => e.TYPE_OF_CHARGE_TRANSFER)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.USER_ID).HasMaxLength(8);

                entity.Property(e => e.VOUCH_ID).HasMaxLength(35);
            });

            modelBuilder.Entity<pexbc2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pexbc2");

                entity.Property(e => e.ADVICE_FORMAT).HasMaxLength(255);

                entity.Property(e => e.ADVICE_ISSUE_BANK).HasMaxLength(255);

                entity.Property(e => e.AUTH_DATE).HasMaxLength(255);

                entity.Property(e => e.AUTOOVERDUE).HasMaxLength(255);

                entity.Property(e => e.BCPastDue).HasMaxLength(255);

                entity.Property(e => e.BENE_INFO).HasMaxLength(255);

                entity.Property(e => e.BPOFlag).HasMaxLength(255);

                entity.Property(e => e.CHARGE_ACC).HasMaxLength(255);

                entity.Property(e => e.COLLECT_REFUND).HasMaxLength(255);

                entity.Property(e => e.COMFIRM_DUE).HasColumnType("datetime");

                entity.Property(e => e.CONFIRM_DATE).HasColumnType("datetime");

                entity.Property(e => e.COVERING_DATE).HasColumnType("datetime");

                entity.Property(e => e.Campaign_EffDate).HasColumnType("datetime");

                entity.Property(e => e.DATELASTACCRU).HasColumnType("datetime");

                entity.Property(e => e.DMS).HasMaxLength(255);

                entity.Property(e => e.DOCUMENT_COPY).HasMaxLength(255);

                entity.Property(e => e.DRAFT).HasMaxLength(255);

                entity.Property(e => e.DateStartAccru).HasColumnType("datetime");

                entity.Property(e => e.DateToStop).HasColumnType("datetime");

                entity.Property(e => e.EVENT_DATE).HasMaxLength(255);

                entity.Property(e => e.FlagBack).HasMaxLength(255);

                entity.Property(e => e.GENACC_DATE).HasColumnType("datetime");

                entity.Property(e => e.GENACC_FLAG).HasMaxLength(255);

                entity.Property(e => e.INTCODE).HasMaxLength(255);

                entity.Property(e => e.INTFLAG).HasMaxLength(255);

                entity.Property(e => e.LASTINTDATE).HasColumnType("datetime");

                entity.Property(e => e.LCOVERDUE).HasMaxLength(255);

                entity.Property(e => e.LC_DATE).HasColumnType("datetime");

                entity.Property(e => e.MT202).HasMaxLength(255);

                entity.Property(e => e.PASTDUEDATE).HasColumnType("datetime");

                entity.Property(e => e.PASTDUEFLAG).HasMaxLength(255);

                entity.Property(e => e.PAYMENTTYPE).HasMaxLength(255);

                entity.Property(e => e.PLUS_MINUS_DISC).HasMaxLength(255);

                entity.Property(e => e.PURCH_DISC_DATE).HasColumnType("datetime");

                entity.Property(e => e.ParTnor_Type1).HasMaxLength(255);

                entity.Property(e => e.ParTnor_Type2).HasMaxLength(255);

                entity.Property(e => e.ParTnor_Type3).HasMaxLength(255);

                entity.Property(e => e.ParTnor_Type4).HasMaxLength(255);

                entity.Property(e => e.ParTnor_Type5).HasMaxLength(255);

                entity.Property(e => e.ParTnor_Type6).HasMaxLength(255);

                entity.Property(e => e.REMIT_CLAIM_TYPE).HasMaxLength(255);

                entity.Property(e => e.SIGHT_DUE_DATE).HasColumnType("datetime");

                entity.Property(e => e.SIGHT_START_DATE).HasColumnType("datetime");

                entity.Property(e => e.TERM_DUE_DATE).HasColumnType("datetime");

                entity.Property(e => e.TERM_START_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasMaxLength(255);

                entity.Property(e => e.VALUE_DATE).HasColumnType("datetime");

                entity.Property(e => e.ValueDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<pexlc1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pexlc1");

                entity.Property(e => e.ACBAHTNET).HasMaxLength(255);

                entity.Property(e => e.ADJUST_LC_REF).HasMaxLength(255);

                entity.Property(e => e.ADJUST_TENOR).HasMaxLength(255);

                entity.Property(e => e.ADVICE_FORMAT).HasMaxLength(255);

                entity.Property(e => e.ADVICE_ISSUE_BANK).HasMaxLength(255);

                entity.Property(e => e.AGENT_BANK_ID).HasMaxLength(255);

                entity.Property(e => e.AGENT_BANK_INFO).HasMaxLength(255);

                entity.Property(e => e.AGENT_BANK_NOSTRO).HasMaxLength(255);

                entity.Property(e => e.AGENT_BANK_REF).HasMaxLength(255);

                entity.Property(e => e.ALLOCATION).HasMaxLength(255);

                entity.Property(e => e.APPLICANT_NAME).HasMaxLength(255);

                entity.Property(e => e.APPVNO).HasMaxLength(255);

                entity.Property(e => e.AUTH_CODE).HasMaxLength(255);

                entity.Property(e => e.AUTH_DATE).HasColumnType("datetime");

                entity.Property(e => e.AUTOOVERDUE).HasMaxLength(255);

                entity.Property(e => e.BENE_ID).HasMaxLength(255);

                entity.Property(e => e.BENE_INFO).HasMaxLength(255);

                entity.Property(e => e.BUSINESS_TYPE).HasMaxLength(255);

                entity.Property(e => e.CCS_ACCT).HasMaxLength(255);

                entity.Property(e => e.CCS_CIFRef).HasMaxLength(255);

                entity.Property(e => e.CCS_CNUM).HasMaxLength(255);

                entity.Property(e => e.CCS_LmType).HasMaxLength(255);

                entity.Property(e => e.CFRRate).HasMaxLength(255);

                entity.Property(e => e.CHARGE_ACC).HasMaxLength(255);

                entity.Property(e => e.CLAIM_FORMAT).HasMaxLength(255);

                entity.Property(e => e.CNTY_CODE).HasMaxLength(255);

                entity.Property(e => e.COLLECT_REFUND).HasMaxLength(255);

                entity.Property(e => e.COMFIRM_DUE).HasColumnType("datetime");

                entity.Property(e => e.CONFIRM_DATE).HasColumnType("datetime");

                entity.Property(e => e.COVERING_DATE).HasColumnType("datetime");

                entity.Property(e => e.COVERING_FOR).HasMaxLength(255);

                entity.Property(e => e.CREDIT_CURRENCY).HasMaxLength(255);

                entity.Property(e => e.CenterID).HasMaxLength(255);

                entity.Property(e => e.Cust_AO).HasMaxLength(255);

                entity.Property(e => e.Cust_LO).HasMaxLength(255);

                entity.Property(e => e.DATELASTACCRU).HasColumnType("datetime");

                entity.Property(e => e.DISCREPANCY_TYPE).HasMaxLength(255);

                entity.Property(e => e.DMS).HasMaxLength(255);

                entity.Property(e => e.DOCUMENT_COPY).HasMaxLength(255);

                entity.Property(e => e.DRAFT).HasMaxLength(255);

                entity.Property(e => e.DRAFT_CCY).HasMaxLength(255);

                entity.Property(e => e.DateStartAccru).HasColumnType("datetime");

                entity.Property(e => e.DateToStop).HasColumnType("datetime");

                entity.Property(e => e.EVENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.EVENT_MODE).HasMaxLength(255);

                entity.Property(e => e.EVENT_TYPE).HasMaxLength(255);

                entity.Property(e => e.EXPORT_LC_NO).HasMaxLength(255);

                entity.Property(e => e.FACNO).HasMaxLength(255);

                entity.Property(e => e.FB_CURRENCY).HasMaxLength(255);

                entity.Property(e => e.FORWARD_CONRACT_NO).HasMaxLength(255);

                entity.Property(e => e.FORWARD_CONRACT_NO1).HasMaxLength(255);

                entity.Property(e => e.FORWARD_CONRACT_NO2).HasMaxLength(255);

                entity.Property(e => e.FORWARD_CONRACT_NO3).HasMaxLength(255);

                entity.Property(e => e.FORWARD_CONRACT_NO4).HasMaxLength(255);

                entity.Property(e => e.FORWARD_CONRACT_NO5).HasMaxLength(255);

                entity.Property(e => e.FORWARD_CONRACT_NO6).HasMaxLength(255);

                entity.Property(e => e.FlagBack).HasMaxLength(255);

                entity.Property(e => e.GENACC_DATE).HasColumnType("datetime");

                entity.Property(e => e.GENACC_FLAG).HasMaxLength(255);

                entity.Property(e => e.GOOD_CODE).HasMaxLength(255);

                entity.Property(e => e.INTCODE).HasMaxLength(255);

                entity.Property(e => e.INTFLAG).HasMaxLength(255);

                entity.Property(e => e.INVOICE).HasMaxLength(255);

                entity.Property(e => e.ISSUE_BANK_ID).HasMaxLength(255);

                entity.Property(e => e.ISSUE_BANK_INFO).HasMaxLength(255);

                entity.Property(e => e.IntRateCode).HasMaxLength(255);

                entity.Property(e => e.LASTINTDATE).HasColumnType("datetime");

                entity.Property(e => e.LCOVERDUE).HasMaxLength(255);

                entity.Property(e => e.LCPastDue).HasMaxLength(255);

                entity.Property(e => e.LC_DATE).HasColumnType("datetime");

                entity.Property(e => e.LC_REF_NO).HasMaxLength(255);

                entity.Property(e => e.METHOD).HasMaxLength(255);

                entity.Property(e => e.MT202).HasMaxLength(255);

                entity.Property(e => e.NARRATIVE).HasColumnType("ntext");

                entity.Property(e => e.PASTDUEDATE).HasColumnType("datetime");

                entity.Property(e => e.PASTDUEFLAG).HasMaxLength(255);

                entity.Property(e => e.PAYMENTTYPE).HasMaxLength(255);

                entity.Property(e => e.PAYMENT_INSTRC).HasColumnType("ntext");

                entity.Property(e => e.PAYMENT_INSTRU).HasMaxLength(255);

                entity.Property(e => e.PLUS_MINUS_DISC).HasMaxLength(255);

                entity.Property(e => e.PURCH_DISC_DATE).HasColumnType("datetime");

                entity.Property(e => e.ParTnor_Type1).HasMaxLength(255);

                entity.Property(e => e.ParTnor_Type2).HasMaxLength(255);

                entity.Property(e => e.ParTnor_Type3).HasMaxLength(255);

                entity.Property(e => e.ParTnor_Type4).HasMaxLength(255);

                entity.Property(e => e.ParTnor_Type5).HasMaxLength(255);

                entity.Property(e => e.ParTnor_Type6).HasMaxLength(255);

                entity.Property(e => e.RECEIVED_NO).HasMaxLength(255);

                entity.Property(e => e.RECORD_TYPE).HasMaxLength(255);

                entity.Property(e => e.REC_STATUS).HasMaxLength(255);

                entity.Property(e => e.REFER_LC_NO).HasMaxLength(255);

                entity.Property(e => e.REIMBURSE_BANK_ID).HasMaxLength(255);

                entity.Property(e => e.REIMBURSE_BANK_INFO).HasMaxLength(255);

                entity.Property(e => e.RELETE_PACK).HasMaxLength(255);

                entity.Property(e => e.REL_CODE).HasMaxLength(255);

                entity.Property(e => e.REMIT_CLAIM_TYPE).HasMaxLength(255);

                entity.Property(e => e.RESTRICT_FR_BK_ADDR1).HasMaxLength(255);

                entity.Property(e => e.RESTRICT_FR_BK_ADDR2).HasMaxLength(255);

                entity.Property(e => e.RESTRICT_FR_BK_ADDR3).HasMaxLength(255);

                entity.Property(e => e.RESTRICT_FR_BK_NAME).HasMaxLength(255);

                entity.Property(e => e.RESTRICT_REFER).HasMaxLength(255);

                entity.Property(e => e.RESTRICT_TO_BK_ADDR1).HasMaxLength(255);

                entity.Property(e => e.RESTRICT_TO_BK_ADDR2).HasMaxLength(255);

                entity.Property(e => e.RESTRICT_TO_BK_ADDR3).HasMaxLength(255);

                entity.Property(e => e.RESTRICT_TO_BK_NAME).HasMaxLength(255);

                entity.Property(e => e.SIGHT_DUE_DATE).HasColumnType("datetime");

                entity.Property(e => e.SIGHT_START_DATE).HasColumnType("datetime");

                entity.Property(e => e.SWIFT_BANK).HasMaxLength(255);

                entity.Property(e => e.SWIFT_DISC).HasColumnType("ntext");

                entity.Property(e => e.SWIFT_MAIL).HasColumnType("ntext");

                entity.Property(e => e.TENOR_DAY_DESC).HasMaxLength(255);

                entity.Property(e => e.TERM_DUE_DATE).HasColumnType("datetime");

                entity.Property(e => e.TERM_START_DATE).HasColumnType("datetime");

                entity.Property(e => e.THIRD_BANK_ID).HasMaxLength(255);

                entity.Property(e => e.THIRD_BANK_INFO).HasMaxLength(255);

                entity.Property(e => e.TXTDOCUMENT).HasColumnType("ntext");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.USER_ID).HasMaxLength(255);

                entity.Property(e => e.VALUE_DATE).HasColumnType("datetime");

                entity.Property(e => e.VOUCH_ID).HasMaxLength(255);

                entity.Property(e => e.ValueDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<pexlc2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pexlc2");

                entity.Property(e => e.ADVICE_FORMAT).HasMaxLength(255);

                entity.Property(e => e.ADVICE_ISSUE_BANK).HasMaxLength(255);

                entity.Property(e => e.AUTH_DATE).HasMaxLength(255);

                entity.Property(e => e.AUTOOVERDUE).HasMaxLength(255);

                entity.Property(e => e.AcceptDate).HasColumnType("datetime");

                entity.Property(e => e.AcceptFlag).HasMaxLength(255);

                entity.Property(e => e.BENE_INFO).HasMaxLength(255);

                entity.Property(e => e.BPOFlag).HasMaxLength(255);

                entity.Property(e => e.CHARGE_ACC).HasMaxLength(255);

                entity.Property(e => e.COLLECT_REFUND).HasMaxLength(255);

                entity.Property(e => e.COMFIRM_DUE).HasColumnType("datetime");

                entity.Property(e => e.CONFIRM_DATE).HasColumnType("datetime");

                entity.Property(e => e.COVERING_DATE).HasColumnType("datetime");

                entity.Property(e => e.Campaign_EffDate).HasColumnType("datetime");

                entity.Property(e => e.DATELASTACCRU).HasColumnType("datetime");

                entity.Property(e => e.DMS).HasMaxLength(255);

                entity.Property(e => e.DOCUMENT_COPY).HasMaxLength(255);

                entity.Property(e => e.DRAFT).HasMaxLength(255);

                entity.Property(e => e.DateStartAccru).HasColumnType("datetime");

                entity.Property(e => e.DateToStop).HasColumnType("datetime");

                entity.Property(e => e.EVENT_DATE).HasMaxLength(255);

                entity.Property(e => e.FlagBack).HasMaxLength(255);

                entity.Property(e => e.GENACC_DATE).HasColumnType("datetime");

                entity.Property(e => e.GENACC_FLAG).HasMaxLength(255);

                entity.Property(e => e.INTCODE).HasMaxLength(255);

                entity.Property(e => e.INTFLAG).HasMaxLength(255);

                entity.Property(e => e.LASTINTDATE).HasColumnType("datetime");

                entity.Property(e => e.LCOVERDUE).HasMaxLength(255);

                entity.Property(e => e.LCPastDue).HasMaxLength(255);

                entity.Property(e => e.LC_DATE).HasColumnType("datetime");

                entity.Property(e => e.MT202).HasMaxLength(255);

                entity.Property(e => e.PASTDUEDATE).HasColumnType("datetime");

                entity.Property(e => e.PASTDUEFLAG).HasMaxLength(255);

                entity.Property(e => e.PAYMENTTYPE).HasMaxLength(255);

                entity.Property(e => e.PLUS_MINUS_DISC).HasMaxLength(255);

                entity.Property(e => e.PURCH_DISC_DATE).HasColumnType("datetime");

                entity.Property(e => e.ParTnor_Type1).HasMaxLength(255);

                entity.Property(e => e.ParTnor_Type2).HasMaxLength(255);

                entity.Property(e => e.ParTnor_Type3).HasMaxLength(255);

                entity.Property(e => e.ParTnor_Type4).HasMaxLength(255);

                entity.Property(e => e.ParTnor_Type5).HasMaxLength(255);

                entity.Property(e => e.ParTnor_Type6).HasMaxLength(255);

                entity.Property(e => e.REMIT_CLAIM_TYPE).HasMaxLength(255);

                entity.Property(e => e.SIGHT_DUE_DATE).HasColumnType("datetime");

                entity.Property(e => e.SIGHT_START_DATE).HasColumnType("datetime");

                entity.Property(e => e.TERM_DUE_DATE).HasColumnType("datetime");

                entity.Property(e => e.TERM_START_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasMaxLength(255);

                entity.Property(e => e.VALUE_DATE).HasColumnType("datetime");

                entity.Property(e => e.ValueDate).HasColumnType("datetime");

                entity.Property(e => e.WithOutFlag).HasMaxLength(255);

                entity.Property(e => e.WithOutType).HasMaxLength(255);
            });

            modelBuilder.Entity<tUnUseAcc>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tUnUseAcc");

                entity.Property(e => e.acctno).HasMaxLength(13);

                entity.Property(e => e.pRefTrans)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.pRefYear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<tmp_BankLiab>(entity =>
            {
                entity.HasKey(e => new { e.Appv_No, e.Bank_Code, e.Facility_No });

                entity.ToTable("tmp_BankLiab");

                entity.Property(e => e.Appv_No).HasMaxLength(15);

                entity.Property(e => e.Bank_Code).HasMaxLength(14);

                entity.Property(e => e.Facility_No).HasMaxLength(13);

                entity.Property(e => e.Credit_Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Limit_Code).HasMaxLength(10);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<tmp_BankLiabCust>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tmp_BankLiabCust");

                entity.Property(e => e.Bank_Code).HasMaxLength(14);

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.DocNumber).HasMaxLength(20);

                entity.Property(e => e.Facility_No).HasMaxLength(13);

                entity.Property(e => e.LiabCcy).HasMaxLength(3);

                entity.Property(e => e.Product).HasMaxLength(4);

                entity.Property(e => e.UserID).HasMaxLength(12);
            });

            modelBuilder.Entity<tmp_Comm>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tmp_Comm");

                entity.Property(e => e.Comm).HasMaxLength(20);

                entity.Property(e => e.CustCode).HasMaxLength(13);

                entity.Property(e => e.CustName).HasMaxLength(70);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Module).HasMaxLength(5);

                entity.Property(e => e.flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<tmp_ExpDM>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tmp_ExpDMS");

                entity.Property(e => e.AppName).HasMaxLength(70);

                entity.Property(e => e.BeneID).HasMaxLength(13);

                entity.Property(e => e.DraftCcy).HasMaxLength(3);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventType).HasMaxLength(20);

                entity.Property(e => e.FlagAmt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Forward).HasMaxLength(15);

                entity.Property(e => e.RefNumber).HasMaxLength(15);
            });

            modelBuilder.Entity<tmp_ForwardCont>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tmp_ForwardCont");

                entity.Property(e => e.CustCode).HasMaxLength(15);

                entity.Property(e => e.CustName).HasMaxLength(70);

                entity.Property(e => e.DocCcy).HasMaxLength(3);

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ForwardNo).HasMaxLength(15);

                entity.Property(e => e.Refno).HasMaxLength(15);

                entity.Property(e => e.flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<tmp_Liability>(entity =>
            {
                entity.HasKey(e => new { e.Appv_No, e.Cust_Code, e.Facility_No });

                entity.ToTable("tmp_Liability");

                entity.Property(e => e.Appv_No).HasMaxLength(15);

                entity.Property(e => e.Cust_Code).HasMaxLength(6);

                entity.Property(e => e.Facility_No).HasMaxLength(13);

                entity.Property(e => e.Credit_Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Limit_Code).HasMaxLength(10);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<tmp_LogIMCB>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tmp_LogIMCBS");

                entity.Property(e => e.LogDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LogFileName).HasMaxLength(100);

                entity.Property(e => e.LogStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PostDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UserId).HasMaxLength(12);
            });

            modelBuilder.Entity<tmp_MainConnect1P>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tmp_MainConnect1P");

                entity.Property(e => e.ACNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ACType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AcName).HasMaxLength(50);

                entity.Property(e => e.OnePReturn).HasMaxLength(100);

                entity.Property(e => e.RqDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RqTime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RsDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RsTime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SumLog).HasMaxLength(50);

                entity.Property(e => e.TrEvent).HasMaxLength(10);

                entity.Property(e => e.TrRefSeq).HasMaxLength(20);

                entity.Property(e => e.TrType).HasMaxLength(10);

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.UserID).HasMaxLength(12);
            });

            modelBuilder.Entity<tmp_SWBankFile>(entity =>
            {
                entity.HasKey(e => e.Bank_Code)
                    .HasName("PK_Tmp_SWBankFile");

                entity.ToTable("tmp_SWBankFile");

                entity.Property(e => e.Bank_Code).HasMaxLength(14);

                entity.Property(e => e.Bank_Add1).HasMaxLength(70);

                entity.Property(e => e.Bank_Add2).HasMaxLength(35);

                entity.Property(e => e.Bank_Add3).HasMaxLength(35);

                entity.Property(e => e.Bank_Add4).HasMaxLength(35);

                entity.Property(e => e.Bank_Swift).HasMaxLength(14);
            });

            modelBuilder.Entity<tmp_Security>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tmp_Security");

                entity.Property(e => e.Hash).HasMaxLength(500);

                entity.Property(e => e.Password).HasMaxLength(70);

                entity.Property(e => e.Salt).HasMaxLength(50);

                entity.Property(e => e.UserID).HasMaxLength(12);
            });

            modelBuilder.Entity<tmp_SwiftInDetail>(entity =>
            {
                entity.HasKey(e => new { e.FileName, e.SwiftInID, e.SwiftInType, e.RunLineNo });

                entity.ToTable("tmp_SwiftInDetail");

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.Property(e => e.SwiftInID).HasMaxLength(30);

                entity.Property(e => e.SwiftInType).HasMaxLength(3);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FieldNo).HasMaxLength(6);

                entity.Property(e => e.LoadDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<tmp_User>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tmp_User");

                entity.Property(e => e.UserBran).HasMaxLength(4);

                entity.Property(e => e.UserDept).HasMaxLength(70);

                entity.Property(e => e.UserExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.UserLevel).HasMaxLength(2);

                entity.Property(e => e.UserLockDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserPassword).HasMaxLength(60);

                entity.Property(e => e.UserPasswordChangeDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserPasswordExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserRemark).HasMaxLength(200);

                entity.Property(e => e.UserStartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<tmp_interest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tmp_interest");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.CustCode).HasMaxLength(13);

                entity.Property(e => e.DocCcy).HasMaxLength(3);

                entity.Property(e => e.DocNo).HasMaxLength(20);

                entity.Property(e => e.DocNo1).HasMaxLength(20);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.KeyNumber).HasMaxLength(15);

                entity.Property(e => e.Module).HasMaxLength(5);

                entity.Property(e => e.ReferNo).HasMaxLength(20);
            });

            modelBuilder.Entity<tmp_rptAmortize>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tmp_rptAmortize");

                entity.Property(e => e.BankCode).HasMaxLength(13);

                entity.Property(e => e.CustCode).HasMaxLength(13);

                entity.Property(e => e.DocCcy).HasMaxLength(3);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.KeyNumber).HasMaxLength(15);

                entity.Property(e => e.Module).HasMaxLength(5);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.WithOutFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.WithOutType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Wref_Bank_ID).HasMaxLength(14);
            });

            modelBuilder.Entity<vBankSumFac>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vBankSumFac");

                entity.Property(e => e.Bank_Code)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.Facility_Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<vCommision>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vCommision");

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.COLLECTION)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.CustCode).HasMaxLength(13);

                entity.Property(e => e.CustName).HasMaxLength(500);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventName).HasMaxLength(30);

                entity.Property(e => e.KeyNumber)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PayFlag)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.RecStatus).HasMaxLength(10);

                entity.Property(e => e.Reference).HasMaxLength(35);

                entity.Property(e => e.RpReceiptNo).HasMaxLength(15);

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.collectrefund).HasMaxLength(25);

                entity.Property(e => e.status)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<vContingent>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vContingent");

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventName).HasMaxLength(25);

                entity.Property(e => e.KeyNumber)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PayFlag)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.UserCode).HasMaxLength(12);
            });

            modelBuilder.Entity<vCustLiability>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vCustLiability");

                entity.Property(e => e.Cust_Code)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Facility_No)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.Facility_Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Revol_Flag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<vCustSumFac>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vCustSumFac");

                entity.Property(e => e.Cust_Code)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Facility_Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<vCustomerAcc>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vCustomerAcc");

                entity.Property(e => e.Cust_AcName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cust_AcNo).HasMaxLength(15);

                entity.Property(e => e.Cust_AcType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Cust_Code)
                    .IsRequired()
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<vExpDMSFTXFTU>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vExpDMSFTXFTU");

                entity.Property(e => e.AppName).HasMaxLength(175);

                entity.Property(e => e.BeneID).HasMaxLength(13);

                entity.Property(e => e.DraftCcy).HasMaxLength(3);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventType).HasMaxLength(25);

                entity.Property(e => e.ForwardCont).HasMaxLength(15);

                entity.Property(e => e.RefNumber)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<vForwardCont>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vForwardCont");

                entity.Property(e => e.CustCode).HasMaxLength(13);

                entity.Property(e => e.CustName)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DocCcy).HasMaxLength(3);

                entity.Property(e => e.DocNo).HasMaxLength(35);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.FCONT_NO1).HasMaxLength(20);

                entity.Property(e => e.FCONT_NO2).HasMaxLength(20);

                entity.Property(e => e.FCONT_NO3).HasMaxLength(20);

                entity.Property(e => e.FCONT_NO4).HasMaxLength(20);

                entity.Property(e => e.FCONT_NO5).HasMaxLength(20);

                entity.Property(e => e.FCONT_NO6).HasMaxLength(20);

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.centerId).HasMaxLength(4);

                entity.Property(e => e.refno).HasMaxLength(35);
            });

            modelBuilder.Entity<vIMFWCONT>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vIMFWCONT");

                entity.Property(e => e.CustCode).HasMaxLength(6);

                entity.Property(e => e.DocCcy).HasMaxLength(3);

                entity.Property(e => e.DocNumber)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<vMasterMonInt>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vMasterMonInt");

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.CENTERID).HasMaxLength(4);

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CustCode).HasMaxLength(13);

                entity.Property(e => e.DocNo).HasMaxLength(20);

                entity.Property(e => e.DocNo1).HasMaxLength(20);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventName).HasMaxLength(25);

                entity.Property(e => e.FlagDue)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KeyNumber)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.OverdueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RecStatus).HasMaxLength(10);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TenorTerm)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TenorType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.collectrefund).HasMaxLength(25);
            });

            modelBuilder.Entity<vMasterOduLoan>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vMasterOduLoan");

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.CENTERID).HasMaxLength(4);

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CustCode).HasMaxLength(13);

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DocNo).HasMaxLength(20);

                entity.Property(e => e.DocNo1)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventName).HasMaxLength(25);

                entity.Property(e => e.FlagDue)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KeyNumber).HasMaxLength(35);

                entity.Property(e => e.LastPayment).HasColumnType("smalldatetime");

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.OverdueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PastDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PayType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RecStatus).HasMaxLength(10);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.TenorTerm)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TenorType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.collectrefund).HasMaxLength(25);
            });

            modelBuilder.Entity<vMonAccured>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vMonAccured");

                entity.Property(e => e.BankType).HasMaxLength(14);

                entity.Property(e => e.CalDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.DocBank).HasMaxLength(14);

                entity.Property(e => e.DocCust).HasMaxLength(6);

                entity.Property(e => e.DocMode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DocNumber).HasMaxLength(3);

                entity.Property(e => e.DocRefer).HasMaxLength(15);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(4);
            });

            modelBuilder.Entity<vMonthAmort>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vMonthAmort");

                entity.Property(e => e.AuthCode)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.CustCode).HasMaxLength(13);

                entity.Property(e => e.DRAFT_CCY).HasMaxLength(3);

                entity.Property(e => e.EVENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.EventName).HasMaxLength(25);

                entity.Property(e => e.KeyNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PURCH_DISC_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.Rec_Status)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.TERM_DUE_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.TenorDesc).HasMaxLength(50);

                entity.Property(e => e.TenorType)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.UserCoede)
                    .IsRequired()
                    .HasMaxLength(12);
            });

            modelBuilder.Entity<vMonthAmortback>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vMonthAmortback");

                entity.Property(e => e.AuthCode)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.CustCode).HasMaxLength(13);

                entity.Property(e => e.DRAFT_CCY).HasMaxLength(3);

                entity.Property(e => e.EVENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.EventName).HasMaxLength(25);

                entity.Property(e => e.KeyNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PURCH_DISC_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.Rec_Status)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.TERM_DUE_DATE).HasColumnType("smalldatetime");

                entity.Property(e => e.TenorDesc).HasMaxLength(50);

                entity.Property(e => e.TenorType)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.UserCoede)
                    .IsRequired()
                    .HasMaxLength(12);
            });

            modelBuilder.Entity<vRefundTax>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vRefundTax");

                entity.Property(e => e.CenterID).HasMaxLength(4);

                entity.Property(e => e.CustCode).HasMaxLength(20);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Reference).HasMaxLength(35);

                entity.Property(e => e.RpCustAc1).HasMaxLength(15);

                entity.Property(e => e.RpCustAc2).HasMaxLength(15);

                entity.Property(e => e.RpCustAc3).HasMaxLength(15);

                entity.Property(e => e.RpPayBy).HasMaxLength(15);
            });

            modelBuilder.Entity<viewBankLSum>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewBankLSum");

                entity.Property(e => e.Bank_Code)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.Facility_No)
                    .IsRequired()
                    .HasMaxLength(13);
            });

            modelBuilder.Entity<viewBankLiab>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewBankLiab");

                entity.Property(e => e.Bank_Code)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.Facility_No)
                    .IsRequired()
                    .HasMaxLength(13);
            });

            modelBuilder.Entity<viewCustLSum>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewCustLSum");

                entity.Property(e => e.Cust_Code)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Facility_No)
                    .IsRequired()
                    .HasMaxLength(13);
            });

            modelBuilder.Entity<viewMasterLoan>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewMasterLoan");

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.CENTERID).HasMaxLength(4);

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CustCode).HasMaxLength(13);

                entity.Property(e => e.DateStartAccru).HasColumnType("smalldatetime");

                entity.Property(e => e.DocNo).HasMaxLength(20);

                entity.Property(e => e.DocNo1)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventName).HasMaxLength(25);

                entity.Property(e => e.FlagDue)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KeyNumber)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.LastPayment).HasColumnType("smalldatetime");

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.OverdueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PastDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PayType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RecStatus).HasMaxLength(10);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TenorTerm)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TenorType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.collectrefund).HasMaxLength(25);
            });

            modelBuilder.Entity<viewMasterODU>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewMasterODU");

                entity.Property(e => e.AuthCode).HasMaxLength(12);

                entity.Property(e => e.CENTERID).HasMaxLength(4);

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CustCode).HasMaxLength(20);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventName).HasMaxLength(25);

                entity.Property(e => e.FlagDue)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KeyNumber)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PastDueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RecStatus).HasMaxLength(10);

                entity.Property(e => e.Reference).HasMaxLength(35);

                entity.Property(e => e.TenorTerm).HasMaxLength(50);

                entity.Property(e => e.TenorType).HasMaxLength(20);

                entity.Property(e => e.UserCode).HasMaxLength(12);

                entity.Property(e => e.collectrefund).HasMaxLength(25);
            });

            modelBuilder.Entity<viewOutISP>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewOutISP");

                entity.Property(e => e.CCS_No).HasMaxLength(20);

                entity.Property(e => e.Ccy).HasMaxLength(3);

                entity.Property(e => e.CustCode).HasMaxLength(20);

                entity.Property(e => e.Cust_CIF).HasMaxLength(20);

                entity.Property(e => e.Cust_Name).HasMaxLength(70);

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.Facility_No).HasMaxLength(13);

                entity.Property(e => e.Facno).HasMaxLength(15);

                entity.Property(e => e.KeyNumber).HasMaxLength(35);

                entity.Property(e => e.Limit_Code).HasMaxLength(10);

                entity.Property(e => e.Module).HasMaxLength(15);
            });

            modelBuilder.Entity<vtempCC>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vtempCCS");

                entity.Property(e => e.CCS_No).HasMaxLength(20);

                entity.Property(e => e.Cust_CIF).HasMaxLength(20);

                entity.Property(e => e.Cust_Code)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Cust_Name).HasMaxLength(70);

                entity.Property(e => e.Facility_No)
                    .IsRequired()
                    .HasMaxLength(13);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
