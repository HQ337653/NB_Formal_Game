using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace NBGame.UI {
    public class BuffIconController : MonoBehaviour
    {
        [SerializeField]
        List<Image> icons;
        Dictionary<Sprite, int> IconWithSprite = new Dictionary<Sprite, int>();
        [SerializeField] Sprite emptySprite;

        public int index = 0;
        public void addIcon(Sprite icon)
        {
            if (!IconWithSprite.ContainsKey(icon))
            {
                IconWithSprite.Add(icon, index);
                icons[index].sprite = icon;
                index += 1;
                if (index >= icons.Count)
                {
                    index = 0;
                }
            }

        }
        public void RemoveIcon(Sprite icon)
        {
            if (IconWithSprite.ContainsKey(icon)) {
                int targetIndex = IconWithSprite[icon];
                for (int i = targetIndex; i < icons.Count - 1; i++)
                {
                    icons[i].sprite = icons[i + 1].sprite;
                    IconWithSprite[icons[i + 1].sprite] = i;
                }
                icons[icons.Count - 1].sprite = emptySprite;
                IconWithSprite.Remove(icon);
                index--;
            }
        }

        public void Init(List<Sprite>  IconList)
        {
            removeAllIcon();

            for(int i =0;( i< icons.Count)&&(i < IconList.Count); i++)
            {
                icons[i].sprite = IconList[i];
                IconWithSprite.Add(IconList[i], index);
            }
        }
        public void removeAllIcon()
        {
            index = 0;
            IconWithSprite = new Dictionary<Sprite, int>();

            for (int i = 0; i < icons.Count; i++)
            {
                icons[i].sprite = emptySprite;
            }
        }
    }
    }