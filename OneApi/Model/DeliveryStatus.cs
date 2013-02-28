namespace OneApi.Model
{
    /// <summary>
    /// Use StringEnum.GetStringValue(DeliveryStatus.[VALUE]) to get the string value of the Enum
    /// </summary>
    public enum DeliveryStatus
    {
        [StringValue("DeliveredToTerminal")]
        DELIVERED_TO_TERMINAL,
        [StringValue("DeliveryUncertain")]
        DELIVERY_UNCERTAIN,
        [StringValue("DeliveryImpossible")]
        DELIVERY_IMPOSSIBLE,
        [StringValue("MessageWaiting")]
        MESSAGE_WAITING,
        [StringValue("DeliveredToNetwork")]
        DELIVERED_TO_NETWORK
    }
}
