namespace Itch.Common.Enums
{
    public enum MessageType
    {
        Timestamp = 'T',
        SystemEvent = 'S',
        StockDirectory = 'R',
        StockTradingAction = 'H',
        RegSHORestriction = 'Y',
        MarketParticipantPosition = 'L',
        AddOrder = 'A',
        AddOrderWithMPID = 'F',
        OrderExecuted = 'E',
        OrderExecutedWithPrice = 'C',
        OrderCancelled = 'X',
        OrderDeleted = 'D',
        OrderReplaced = 'U',
        TradeMessageNonCross = 'P',
        CrossTradeMessage = 'Q',
        BrokenTrade = 'B',
        NetOrderImbalanceIndicator = 'I'
    }

    public enum SystemEventCode
    {
        StartOfMessages = 'O',
        StartOfSystemHours = 'S',
        StartOfMarketHours = 'Q',
        EndOfMarketHours = 'M',
        EndOfSystemHours = 'E',
        EndOfMessages = 'C',
        EMCHalt = 'A',
        EMCQuoteOnlyPeriod = 'R',
        EMCResumption = 'B'
    }

    public enum MarketCategory
    {
        NYSE = 'N',
        NYSEAmex = 'A',
        NYSEArca = 'P',
        NASDAQGlobalSelectMarket = 'Q',
        NASDAQGlobalMarket = 'G',
        NASDAQCapitalMarket = 'S'
    }

    public enum FinancialStatusIndicator
    {
        Deficient = 'D',
        Delinquent = 'E',
        Bankrupt = 'Q',
        Suspended = 'S',
        DeficientAndBankrupt = 'G',
        DeficientAndDelinquent = 'H',
        DelinquentAndBankrupt = 'J',
        DeficientDelinquentAndBankrupt = 'K',
        InCompliance = ' '
    }

    public enum RoundLotsOnly
    {
        Yes = 'Y',
        No = 'N'
    }

    public enum TradingState
    {
        HaltedAcrossAllUSEquityMarkets = 'H',
        HaltedOnNASDAQ = 'V',
        QuotationOnlyPeriodForSROHalt = 'Q',
        QuotationOnlyForNASDAQHalt = 'R',
        TradingOnNASDAQ = 'T'
    }

    public enum RegSHOAction
    {
        NoPriceTestInPlace = '1',
        IntradayPriceDropSHOShortSalePriceTestRestriction = '1',
        RegSHOShortSalePriceTestRestriction = '2'
    }

    public enum PrimaryMarketMaker
    {
        Yes = 'Y',
        No = 'N'
    }

    public enum MarketMakerMode
    {
        Normal = 'N',
        Passive = 'P',
        Syndicate = 'S',
        PreSyndicate = 'R',
        Penalty = 'L'
    }

    public enum MarketParticipantState
    {
        Active = 'A',
        ExcusedOrWithdrawn = 'E',
        Withdrawn = 'W',
        Suspended = 'S',
        Deleted = 'D'
    }

    public enum BuySellIndicator
    {
        Buy = 'B',
        Sell = 'S'
    }

    public enum Printable
    {
        NonPrintable = 'N',
        Printable = 'Y'
    }

    public enum CrossType
    {
        NASDAQOpeningCross = 'O',
        NASDAQClosingCross = 'C',
        CrossForIPOAndHaltedSecurities = 'H',
        NASDAQCrossNetwork = 'I'
    }

    public enum ImbalanceDirection
    {
        BuyImbalance = 'B',
        SellImbalance = 'S',
        NoImbalance = 'N',
        InsufficientOrdersToCalculate = 'O'
    }

    public enum PriceVariationIndicator
    {
        LessThanOnePercent = 'L',
        OneToTwoPercent = '1',
        TwoToThreePercent = '2',
        ThreeToFourPercent = '3',
        FourToFivePercent = '4',
        FiveToSixPercent = '5',
        SixToSevenPercent = '6',
        SevenToEightPercent = '7',
        EightToNinePercent = '8',
        NineToTenPercent = '9',
        TenToTwentyPercent = 'A',
        TwentyToThirtyPercent = 'B',
        GreaterThanThirtyPercent = 'C',
        CannotCalculate = ' '
    }
}