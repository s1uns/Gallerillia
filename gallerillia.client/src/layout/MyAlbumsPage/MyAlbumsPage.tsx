import { FC, useState } from "react";
import { AlbumProps } from "../../components/Album/Album";
import { AlbumsList } from "../../components/AlbumsList/AlbumsList";
import { Pagination } from "../../components/Pagination/Pagination";
import styles from "./MyAlbumsPage.module.scss";

export const MyAlbumsPage: FC = () => {
    const [albums, setAlbums] = useState<AlbumProps[]>([
        { id: "1", title: "Family", imgUrl: "", author: "Illia" },
        {
            id: "2",
            title: "Life",
            imgUrl: "https://i0.wp.com/picjumbo.com/wp-content/uploads/beautiful-nature-mountain-scenery-with-flowers-free-photo.jpg?w=600&quality=80",
            author: "Michael",
        },
        {
            id: "3",
            title: "Life",
            imgUrl: "https://static.remove.bg/sample-gallery/graphics/bird-thumbnail.jpg",
            author: "Illia",
        },
        {
            id: "4",
            title: "Study",
            imgUrl: "https://images.squarespace-cdn.com/content/v1/56b1148fe707ebac7ac5d685/1659916527594-0QOSGRAEFR3ZKPAIRBKI/studying-ahead-1421056.jpg",
            author: "George",
        },
        { id: "5", title: "Nature", imgUrl: "", author: "Betsy" },
    ]);
    return (
        <div className={styles["album-page"]}>
            <div className={styles["container"]}>
                <AlbumsList albumsType="All Albums" albums={albums} />
                <Pagination
                    currentPage={0}
                    onChangePage={() => {}}
                    totalPages={15}
                />
            </div>
        </div>
    );
};
