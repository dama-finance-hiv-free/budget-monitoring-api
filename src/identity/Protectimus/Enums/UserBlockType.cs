﻿namespace IdentityProvider.Protectimus.Enums;

public enum UserBlockType
{
    NONE_BLOCKED, BLOCKED_BY_ADMIN, TOO_MANY_LOGIN_FAILED_ATTEMPTS_BLOCKED, TOO_MANY_OTP_FAILED_ATTEMPTS_BLOCKED, TOO_MANY_EMAIL_FAILED_ATTEMPTS_BLOCKED, TOO_MANY_PIN_FAILED_ATTEMPTS_BLOCKED
}