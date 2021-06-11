using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ISRPOInv
{
    class EQP
    {
        Database1Entities db;
        public bool Add(string eqp, string cab)
        {
            db = new Database1Entities();
            Equip equip = new Equip();
            try
            {
                var last_id = db.Equip.Max(f => f.Id);
                if (eqp == "")
                {
                    MessageBox.Show("Вы заполнили не все поля", "Инвентаризация", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (cab == "")
                {
                    MessageBox.Show("Вы не выбрали кабинет", "Инвентаризация", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                switch (Convert.ToInt32(eqp))
                {
                    case 0:
                        equip.cab = cab;
                        equip.name = "Монитор";
                        equip.num = cab + "MN" + (last_id + 1);
                        db.Equip.Add(equip);
                        db.SaveChanges();
                        break;
                    case 1:
                        equip.cab = cab;
                        equip.name = "Стол";
                        equip.num = cab + "DK" + (last_id + 1);
                        db.Equip.Add(equip);
                        db.SaveChanges();
                        break;
                    case 2:
                        equip.cab = cab;
                        equip.name = "Стул";
                        equip.num = cab + "CR" + (last_id + 1);
                        db.Equip.Add(equip);
                        db.SaveChanges();
                        break;
                    case 3:
                        equip.cab = cab;
                        equip.name = "Компьютер";
                        equip.num = cab + "PC" + (last_id + 1);
                        db.Equip.Add(equip);
                        db.SaveChanges();
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка", "Инвентаризация", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Delete(string id)
        {
            db = new Database1Entities();
            Equip equip = new Equip();
            try
            {
                int num = Convert.ToInt32(id);
                var d_e = db.Equip.Where(i => i.Id == num).FirstOrDefault();
                if (d_e == null)
                {
                    MessageBox.Show("Вы не выбрали строку", "Инвентаризация", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Equip.Remove(d_e);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка", "Инвентаризация", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
