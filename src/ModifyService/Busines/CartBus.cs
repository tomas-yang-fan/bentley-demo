using ModifyService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModifyService.Busines
{
    public interface ICartBus {
        public int AddItemToCart(Item item);
        public int DeleteCartItem(string itemNumber);

        public void addToOrder();

        public int UpdataOrder(int transactionNumber);
    }
    public class CartBus:ICartBus
    {
        private ICartDAO cartDAO;
        public CartBus(ICartDAO cartDAO)
        {
            this.cartDAO = cartDAO;
        }
        public int AddItemToCart(Item item)
        {

            string sql = $@"INSERT INTO Tomas_Cart (
                                            UserID
	                                        ,ItemNumber
	                                        ,ItemDescription
	                                        ,UnitPrice
	                                        ,Cost
	                                        ,Qty
	                                        ,InDate
	                                        ,InUser
	                                        )
                                        VALUES(
                                            'tomas'
                                            , '{item.ItemNumber}'
                                            , '{item.ItemDescription}'
                                            , {item.UnitPrice}
                                            , {item.Cost}
                                            , {item.Qty}
                                            , '{DateTime.Now.ToString("yyyy-MM-dd")}'
                                            , 'Tomas yang'
                                            )
                            ";
            return this.cartDAO.AddItemToCart(sql);
        }
        public int UpdataOrder(int transactionNumber)
        {

            string sql = $@"Update Tomas_OrderMaster 
                            Set Status = 'S'
                            Where TransactionNumber = {transactionNumber}
                            ";
            return this.cartDAO.UpdataOrder(sql);
        }
        public int DeleteCartItem(string itemNumber)
        {
            string sql = $@"delete Tomas_Cart
                            where ItemNumber = '{itemNumber}'";
            return this.cartDAO.DeleteCartItem(sql);
        }

        public void addToOrder()
        {
            string sql = $@"
DECLARE @PriceAmount DECIMAL
	,@CostAmount DECIMAL
	,@MasterTransactionNumber INT

SELECT @PriceAmount = sum(UnitPrice * Qty)
	,@CostAmount = sum(Cost * Qty)
FROM Tomas_Cart

BEGIN TRY
    BEGIN TRANSACTION
	INSERT INTO Tomas_OrderMaster (
		UserID
		,OrderNumber
		,STATUS
		,PriceAmount
		,CostAmount
		,InDate
		,InUser
		)
	VALUES (
		'Tomas'
		,'{DateTime.Now.ToString("yyyyMMddHHmmss")}'
		,'I'
		,@PriceAmount
		,@CostAmount
        ,GetDate()
        ,'Tomas yang'
		)

	SET @MasterTransactionNumber = SCOPE_IDENTITY()

	INSERT INTO Tomas_OrderTransaction (
		MasterTransaction
		,ItemNumber
		,ItemDescription
		,UnitPrice
		,Cost
		,Qty
		,InDate
		,InUser
		)
	SELECT @MasterTransactionNumber
		,ItemNumber
		,ItemDescription
		,UnitPrice
		,Cost
		,Qty
        ,'{DateTime.Now.ToString("yyyy-MM-dd")}'
        ,'Tomas yang'
	FROM Tomas_Cart

	COMMIT TRANSACTION
END TRY

BEGIN CATCH
	IF XACT_STATE() <> 0
	BEGIN
		ROLLBACK TRANSACTION;
	END

	DECLARE @ERROR_MESSAGE NVARCHAR(4000) = ERROR_MESSAGE()

	RAISERROR (
			@ERROR_MESSAGE
			,16
			,1
			)
END CATCH
";
            this.cartDAO.addToOrder(sql);
        }

    }
}
