import { FC, useState } from "react";
import { AlbumProps } from "../../components/Album/Album";
import styles from "./Home.module.scss";
import { Pagination } from "../../components/Pagination/Pagination";
import { AlbumsList } from "../../components/AlbumsList/AlbumsList";

export const Home: FC = () => {
    const [albums, setAlbums] = useState<AlbumProps[]>([
        { id: "1", title: "Nature", imgUrl: "", author: "Illia" },
        {
            id: "2",
            title: "Life",
            imgUrl: "https://i0.wp.com/picjumbo.com/wp-content/uploads/beautiful-nature-mountain-scenery-with-flowers-free-photo.jpg?w=600&quality=80",
            author: "Michael",
        },
        {
            id: "3",
            title: "Family",
            imgUrl: "https://static.remove.bg/sample-gallery/graphics/bird-thumbnail.jpg",
            author: "Illia",
        },
        { id: "4", title: "Nature", imgUrl: "", author: "George" },
        { id: "5", title: "Nature", imgUrl: "", author: "Betsy" },
    ]);
    return (
        <div className={styles["home"]}>
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
