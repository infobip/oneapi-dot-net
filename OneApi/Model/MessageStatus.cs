namespace OneApi.Model
{
    /// <summary>
    /// Use StringEnum.GetStringValue(MessageStatus.[VALUE]) to get the string value of the Enum
    /// </summary>
    public enum MessageStatus
    {
        [StringValue("MessageNotSent")]
        MESSAGE_NOT_SENT,
        [StringValue("MessageSent")]
        MESSAGE_SENT,
        [StringValue("MessageWaitingForDelivery")]
        MESSAGE_WAITING_DELIVERY,
        [StringValue("MessageNotDelivered")]
        MESSAGE_NOT_DELIVERED,
        [StringValue("MessageDelivered")]
        MESSAGE_DELIVERED,
        [StringValue("NetworkNotAllowed")]
        MESSAGE_NETWORK_NOT_ALLOWED,
        [StringValue("NetworkNotAvailable")]
        MESSAGE_NETWORK_NOT_AVAILABLE,
        [StringValue("InvalidDestinationAddress")]
        MESSAGE_INVALID_DESTINATION_ADDRESS,
        [StringValue("MessageDeliveryUnknown")]
        MESSAGE_DELIVERY_UNKNOWN,
        [StringValue("RouteNotAvailable")]
        ROUTE_NOT_AVAILABLE,
        [StringValue("InvalidSourceAddress")]
        INVALID_SOURCE_ADDRESS,
        [StringValue("NotEnoughCredits")]
        NOT_ENOUGH_CREDITS,
        [StringValue("MessageRejected")]
        MESSAGE_REJECTED,
        [StringValue("MessageExpired")]
        MESSAGE_EXPIRED,
        [StringValue("SystemError")]
        SYSTEM_ERROR,
        [StringValue("MessageAccepted")]
        MESSAGE_ACCEPTED
    }
}
