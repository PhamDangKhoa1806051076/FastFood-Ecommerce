using System.Collections.Generic;

namespace FastFoodEcommerce.Helpers
{
    public static class LanguageHelper
    {
        private static readonly Dictionary<string, Dictionary<string, string>> _translations = new()
        {
            ["vi"] = new()
            {
                ["Home"] = "Trang chủ",
                ["Menu"] = "Thực đơn",
                ["Promotion"] = "Khuyến mãi",
                ["Stores"] = "Hệ thống cửa hàng",
                ["Cart"] = "Giỏ hàng",
                ["Login"] = "Đăng nhập",
                ["Register"] = "Đăng ký",
                ["Slogan"] = "Đặt món ngon - Ship tận nơi - Niềm vui trọn vẹn",
                ["OrderNow"] = "Đặt hàng ngay",
                ["FindStore"] = "Tìm cửa hàng",
                ["AllProducts"] = "Tất cả sản phẩm",
                ["AddToCart"] = "Thêm vào giỏ",
                ["Language"] = "Tiếng Việt",
                ["English"] = "Tiếng Anh",
                ["Vietnamese"] = "Tiếng Việt",
                ["Korean"] = "Tiếng Hàn",
                ["VoucherCode"] = "Mã giảm giá",
                ["Expired"] = "Đã hết hạn",
                ["CopyCode"] = "Sao chép mã",
                ["Address"] = "Địa chỉ",
                ["Phone"] = "Số điện thoại",
                ["ConfirmOTP"] = "Xác nhận OTP",
                ["VerifyPhone"] = "Xác nhận số điện thoại"
            },
            ["en"] = new()
            {
                ["Home"] = "Home",
                ["Menu"] = "Menu",
                ["Promotion"] = "Promotions",
                ["Stores"] = "Stores",
                ["Cart"] = "Cart",
                ["Login"] = "Login",
                ["Register"] = "Register",
                ["Slogan"] = "Delicious Food - Fast Delivery - Pure Joy",
                ["OrderNow"] = "Order Now",
                ["FindStore"] = "Find a Store",
                ["AllProducts"] = "All Products",
                ["AddToCart"] = "Add to Cart",
                ["Language"] = "English",
                ["English"] = "English",
                ["Vietnamese"] = "Vietnamese",
                ["Korean"] = "Korean",
                ["VoucherCode"] = "Voucher Code",
                ["Expired"] = "Expired",
                ["CopyCode"] = "Copy Code",
                ["Address"] = "Address",
                ["Phone"] = "Phone Number",
                ["ConfirmOTP"] = "Confirm OTP",
                ["VerifyPhone"] = "Verify Phone"
            },
            ["ko"] = new()
            {
                ["Home"] = "홈",
                ["Menu"] = "메뉴",
                ["Promotion"] = "프로모션",
                ["Stores"] = "매장 찾기",
                ["Cart"] = "장바구니",
                ["Login"] = "로그인",
                ["Register"] = "회원가입",
                ["Slogan"] = "맛있는 음식 - 빠른 배달 - 순수한 즐거움",
                ["OrderNow"] = "지금 주문하기",
                ["FindStore"] = "매장 찾기",
                ["AllProducts"] = "모든 제품",
                ["AddToCart"] = "장바구니에 담기",
                ["Language"] = "한국어",
                ["English"] = "영어",
                ["Vietnamese"] = "베트남어",
                ["Korean"] = "한국어",
                ["VoucherCode"] = "바우처 코드",
                ["Expired"] = "만료됨",
                ["CopyCode"] = "코드 복사",
                ["Address"] = "주소",
                ["Phone"] = "전화번호",
                ["ConfirmOTP"] = "OTP 확인",
                ["VerifyPhone"] = "전화번호 확인"
            }
        };

        public static string Get(string key, string culture)
        {
            if (!_translations.ContainsKey(culture)) culture = "en";
            return _translations[culture].ContainsKey(key) ? _translations[culture][key] : key;
        }
    }
}
