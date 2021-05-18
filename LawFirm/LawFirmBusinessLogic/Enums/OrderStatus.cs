﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmBusinessLogic.Enums
{     /// <summary>     
      /// Статус заказа     
      /// /// </summary>     
    public enum OrderStatus
    {
        Принят = 0,
        Выполняется = 1,
        Готов = 2,
        Оплачен = 3,
        Нехватка_материалов = 4
    }
}